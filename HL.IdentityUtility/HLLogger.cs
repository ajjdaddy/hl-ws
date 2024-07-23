using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using HL.Shared;

namespace HL.IdentityUtility
{
    public class HLLogger : IHLLogger
    {
        private string _logType = "Web";
        private static ILogger _logger;
        private bool _loggingEnabled = true;
        private string _filePath;

        public HLLogger()
        {
            _logType = "Default";
            LogEventLevel level = LogEventLevel.Information;
            _filePath = Path.Combine(SetTmpFolder(), "HLIdentityService.log");

            if (DbParameters.HLIdentityConfig.IsDebug == 1)
            {
                _logger = new LoggerConfiguration()
                    .MinimumLevel.Is(level)
                    .Enrich.WithProperty("Version", 1)
                    .WriteTo.File(new CompactJsonFormatter(), _filePath, shared: true)
                    .CreateLogger();
            }
        }

        private string SetTmpFolder()
        {
            if (DbParameters.HLIdentityConfig == null)
            {
                DbParameters.GetDbConfig();
            }

            return DbParameters.DebugFolder;

        }
        public HLLogger(string logType = null)
        {
            _logType = logType == null ? "Http" : logType;
            LogEventLevel level = LogEventLevel.Information;
            _filePath = Path.Combine(DbParameters.DebugFolder, "HLIdentityService.log");

            if (DbParameters.HLIdentityConfig.IsDebug == 1)
            {
                _logger = new LoggerConfiguration()
                .MinimumLevel.Is(level)
                .Enrich.WithProperty("Version", 1)
                .WriteTo.File(new CompactJsonFormatter(), _filePath, shared: true)
                .CreateLogger();
            }
        }

        public void WriteLogError(string errorCode, string function, string msg)
        {
            if (_logger == null)
                return;

            _logger
                .ForContext("Class", _logType)
                .ForContext("Method", function)
                .ForContext("Error", errorCode)
                .Error(msg);
        }

        public void WriteLogInformation(string errorCode, string function, string msg)
        {
            if (_logger == null)
                return;

            _logger
                .ForContext("Class", _logType)
                .ForContext("Method", function)
                .ForContext("Error", errorCode)
                .Information(msg);
        }

        public void WriteLogWarning(string errorCode, string function, string msg)
        {
            if (_logger == null)
                return;

            _logger
                .ForContext("Class", _logType)
                .ForContext("Method", function)
                .ForContext("Error", errorCode)
                .Warning(msg);
        }
    }
}
