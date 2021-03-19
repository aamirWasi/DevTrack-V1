using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
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
        private static IKeyboardTrackStartService _keyboardTrackStart;
        private static IMouseTrackStartService _mouseTrackStart;

        public Worker(
            ILogger<Worker> logger,
            ITrackerService trackerService,
            IKeyboardTrackStartService keyboardTrackStartService,
            IMouseTrackStartService mouseTrackStartService)
        {
            _logger = logger;
            _trackerService = trackerService;
            _keyboardTrackStart = keyboardTrackStartService;
            _mouseTrackStart = mouseTrackStartService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mouseThread = new Thread(_mouseTrackStart.MouseTrack);
            var keyboardThread = new Thread(_keyboardTrackStart.KeyboardTrack);

            keyboardThread.Start();
            mouseThread.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                _trackerService.Track();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            
            }
        }
    }
}