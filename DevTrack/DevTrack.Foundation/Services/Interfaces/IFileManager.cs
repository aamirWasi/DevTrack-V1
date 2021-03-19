namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IFileManager
    {
        string GetFilePath(string filePath);
        string GetFilePath();
        void RemoveFileFromDirectory(string path);
    }
}