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
        private readonly ITrackerService _trackerService;
        private static IKeyboardTrackService _keyboardTrackService;
        private static IMouseTrackService _mouseTrackService;

        public Worker(
            ILogger<Worker> logger,
            ITrackerService trackerService,
            IKeyboardTrackService keyboardTrackService,
            IMouseTrackService mouseTrackService)
        {
            _logger = logger;
            _trackerService = trackerService;
            _keyboardTrackService = keyboardTrackService;
            _mouseTrackService = mouseTrackService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mouseThread = new Thread(_mouseTrackService.Track);
            var keyboardThread = new Thread(_keyboardTrackService.Track);

            keyboardThread.Start();
            mouseThread.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                _trackerService.Track();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(60000, stoppingToken);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}