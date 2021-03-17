namespace DevTrack.Foundation.Services
{
    public interface IFileManager
    {
        string GetFilePath(string filePath);
        string GetFilePath();
        void RemoveFileFromDirectory(string path);
    }
}