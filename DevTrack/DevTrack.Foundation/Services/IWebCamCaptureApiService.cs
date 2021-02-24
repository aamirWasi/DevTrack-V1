using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IWebCamCaptureApiService
    {
        string SaveCampuredImageInSql(WebCamCaptureImage imageEntity);
    }
}