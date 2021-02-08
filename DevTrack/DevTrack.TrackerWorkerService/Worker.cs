using DevTrack.Foundation.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using DevTrack.Foundation.Adapters;

namespace DevTrack.TrackerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITrackerService _trackerService;
        private static IKeyboardTrackAdapter _keyboardTrackAdapter;
        private static IMouseTrackAdapter _mouseTrackAdapter;

        public Worker(
            ILogger<Worker> logger,
            ITrackerService trackerService,
            IKeyboardTrackAdapter keyboardTrackAdapter,
            IMouseTrackAdapter mouseTrackAdapter)
        {
            _logger = logger;
            _trackerService = trackerService;
            _keyboardTrackAdapter = keyboardTrackAdapter;
            _mouseTrackAdapter = mouseTrackAdapter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mouseThread = new Thread(_mouseTrackAdapter.MouseTrack);
            var keyboardThread = new Thread(_keyboardTrackAdapter.KeyboardTrack);

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