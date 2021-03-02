namespace DevTrack.Foundation.Services
{
    public interface IHelper
    {
        string GetFilePath(string filePath);
        void RemoveFileFromDirectory(string path);
    }
}