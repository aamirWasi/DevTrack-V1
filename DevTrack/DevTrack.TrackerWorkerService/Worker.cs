using DevTrack.Foundation.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevTrack.TrackerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISnapShotService _snapShotService;
        private readonly ILoggerInputService _loggerInputService;
        private const int minValue = 1;
        private const int maxValue = 10;

        public Worker(ILogger<Worker> logger, ISnapShotService snapShotService, ILoggerInputService loggerInputService)
        {
            _logger = logger;
            _snapShotService = snapShotService;
            _loggerInputService = loggerInputService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Random random = new Random();
                int number = random.Next(minValue, maxValue);
                _logger.LogInformation(_loggerInputService.LogMessage());
                var timeSpan = (int)TimeSpan.FromMinutes(number).TotalMilliseconds;
                await Task.Delay(timeSpan, stoppingToken);
                _snapShotService.SnapshotCapturer();
            }
        }
    }
}
