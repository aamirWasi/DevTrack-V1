using System;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class Helper : IHelper
    {
        public string GetFilePath(string filePath)
        {
            var path = Environment.CurrentDirectory;
            const string imageDirectory = "ScreenShotReceiver";
            return Path.Combine(path, imageDirectory, filePath);
        }
    }
}