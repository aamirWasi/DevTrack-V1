using DevTrack.Foundation.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace DevTrack.TrackerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                Console.WriteLine("Running");


                WebCamCaptureService cam = new WebCamCaptureService();
                Image image = cam.WebCamCapture();
                string path = @"C:\camTest\";
                string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");
                image.Save(string.Format(path + FileName + ".jpg"));


                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
