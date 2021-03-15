using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Adapters
{
    public interface IWebCamCaptureAdapterService
    {
        string WebHttpResponse(WebCamCaptureImage imageEntity);
    }
}