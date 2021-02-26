using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IWebCamCaptureApiService
    {
        string SaveCapturedImageInSql(WebCamCaptureImage imageEntity);
    }
}