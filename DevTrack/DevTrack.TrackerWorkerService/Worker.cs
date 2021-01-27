using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using DevTrack.Foundation.Services;

namespace DevTrack.TrackerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITrackerService _tracker;

        public Worker(ILogger<Worker> logger, ITrackerService tracker)
        {
            _logger = logger;
            _tracker = tracker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _tracker.Track();
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
