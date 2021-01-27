using System;

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