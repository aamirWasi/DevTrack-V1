using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.SyncWokerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITrackerService _trackerService;

        public Worker(ILogger<Worker> logger, ITrackerService trackerService)
        {
            _logger = logger;
            _trackerService = trackerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var first = false;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (CheckForInternetConnection() && first)
                {
                   _trackerService.Sync();
                }

                first = true;

                await Task.Delay(10000, stoppingToken);
            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using var client = new WebClient();
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
