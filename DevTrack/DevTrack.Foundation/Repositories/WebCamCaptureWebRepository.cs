using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class WebCamCaptureWebRepository : Repository<WebCamCaptureImage, int, DevTrackWebContext>, IWebCamCaptureWebRepository
    {
        public WebCamCaptureWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}
