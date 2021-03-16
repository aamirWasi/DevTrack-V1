using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IWebCamCaptureWebService
    {
        void SaveSnapShotWebDb(WebCamCaptureImage image);
        string SaveSnapshotInSql(WebCamCaptureImage imageEntity);
    }
}