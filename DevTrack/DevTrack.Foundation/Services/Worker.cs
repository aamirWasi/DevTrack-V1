using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
       
        private readonly IActiveWindowsService _activeWindowsService;
        public Worker(ILogger<Worker> logger, IActiveWindowsService activeWindowsService)
        {
            _logger = logger;
            _activeWindowsService = activeWindowsService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                 _logger.LogInformation(_activeWindowsService.GetActiveWindow());
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
