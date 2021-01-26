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
        private readonly IWebCamCaptureService _webCamCaptureService;

        public Worker(ILogger<Worker> logger, IWebCamCaptureService webCamCaptureService)
        {
            _logger = logger;
            _webCamCaptureService = webCamCaptureService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //DevTrack.Foundation.Services.WebCamCaptureService webCamCapture = new Foundation.Services.WebCamCaptureService();
                //webCamCapture.Capture();

                _webCamCaptureService.Capture();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
