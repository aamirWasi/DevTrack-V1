namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IWebCamCaptureLocalService
    {
        void RemoveImageFromFolder(string path);
        void RemoveImageFromSqLite(string returnResult, int id);
    }
}