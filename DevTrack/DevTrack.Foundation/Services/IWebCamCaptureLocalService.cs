namespace DevTrack.Foundation.Services
{
    public interface IWebCamCaptureLocalService
    {
        void RemoveImageFromFolder(string path);
        void RemoveImageFromSqLite(string returnResult, int id);
    }
}