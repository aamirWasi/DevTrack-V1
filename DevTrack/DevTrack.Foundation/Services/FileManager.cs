using System;
using System.IO;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class FileManager : IFileManager
    {
        readonly string path = Environment.CurrentDirectory;
        const string imageDirectory = "ScreenShotReceiver";

        public string GetFilePath(string filePath)
        {
            return Path.Combine(path, imageDirectory, filePath);
        }

        public string GetFilePath()
        {
            return Path.Combine(path, imageDirectory);
        }

        public void RemoveFileFromDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidOperationException("Path must be provided");
            }
            else
            {
                File.Delete(path);
            }
        }
    }
}