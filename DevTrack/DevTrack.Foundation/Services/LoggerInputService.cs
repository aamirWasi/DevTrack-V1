using System;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class LoggerInputService : ILoggerInputService
    {
        public string LogMessage()
        {
            return $"Screenshot capture at: {DateTimeOffset.UtcNow}";
        }
    }
}