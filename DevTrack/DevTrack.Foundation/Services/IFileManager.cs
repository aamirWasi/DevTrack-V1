namespace DevTrack.Foundation.Services
{
    public interface IFileManager
    {
        string GetFilePath(string filePath);
        void RemoveFileFromDirectory(string path);
    }
}