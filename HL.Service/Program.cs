using Microsoft.Extensions.Hosting.WindowsServices;
using HL.IdentityUtility;
using HL.IdentityCache;
using Microsoft.AspNetCore.HttpOverrides;
using System.Diagnostics;
using HL.Service.Services;
using HL.Shared;

DbParameters.GetDbConfig();
string fname = "hl-identity.db";
string DbFile = Path.Combine(DbParameters.HLIdentityConfig.CacheFolder, fname);

if (DbParameters.HLIdentityConfig.HLServiceInStandaloneMode == 1 && (!File.Exists(DbFile) || new FileInfo(DbFile).Length == 0))
{
    string template = "Unknown";

    try
    {
        template = Path.Combine(AppContext.BaseDirectory, "hl-identity.db");

        if (File.Exists(DbFile))
            File.Delete(DbFile);

        if (File.Exists(template))
        {
            File.Copy(template, DbFile);
        }
    }
    catch (Exception ex)
    {
        EventLog.WriteEntry("HL Service", "Unable to create cache template:" + ex.Message, EventLogEntryType.Error);
    }
}

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
};

var builder = WebApplication.CreateBuilder(options);
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddControllers();
builder.Services.AddSingleton<ICacheManager, CacheManager>();

// Run HL Sync with configured interval
builder.Services.AddHostedService<HLServiceSync>();

// serilog
builder.Services.AddSingleton<IHLLogger,HLLogger>();

builder.Host.UseWindowsService(options =>
{
    options.ServiceName = "HL Identity Service";
});

var app = builder.Build();
app.UseForwardedHeaders();
app.UseRouting();

// rewind raw post data automatically
app.Use((context,next) => {
    context.Request.EnableBuffering();
    return next(context);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}");
});

await app.RunAsync();
