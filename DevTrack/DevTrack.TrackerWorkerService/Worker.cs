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
        private readonly IRunningProgramService _runningProgramService;

        public Worker(ILogger<Worker> logger, IRunningProgramService runningProgramService)
        {
            _logger = logger;
            _runningProgramService = runningProgramService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _runningProgramService.GetProcesses();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
