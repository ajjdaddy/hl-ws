using HL.IdentitySync;
using HL.IdentityUtility;
using HL.Shared;

namespace HL.Service.Services
{
    public class HLServiceSync : BackgroundService
    {
        private readonly IHLSync hlSync;
        private readonly IHLLogger _hlLogger;

        public HLServiceSync(IHLSync pHLSync, IHLLogger hlLogger)
        {
            hlSync = pHLSync;
            _hlLogger = hlLogger;
        }

        /// <summary>
        /// TODO: Implement HL auto-sync periodically
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            _hlLogger.WriteLogInformation("", "HLSynch", "HLSync is starting...");

            // make sure we have latest settings from dbparameters
            DbParameters.GetDbConfig();
        }
    }
}
