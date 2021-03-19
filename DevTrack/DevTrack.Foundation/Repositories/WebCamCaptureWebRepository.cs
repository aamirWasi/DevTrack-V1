using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class WebCamCaptureWebRepository : Repository<WebCamCaptureImage, int, DevTrackWebContext>, IWebCamCaptureWebRepository
    {
        public WebCamCaptureWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}
