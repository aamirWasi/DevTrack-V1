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
            File.Delete(path);
        }
    }
}