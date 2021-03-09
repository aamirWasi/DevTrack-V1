using System;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class FileManager : IFileManager
    {
        public string GetFilePath(string filePath)
        {
            var path = Environment.CurrentDirectory;
            const string imageDirectory = "ScreenShotReceiver";
            return Path.Combine(path, imageDirectory, filePath);
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