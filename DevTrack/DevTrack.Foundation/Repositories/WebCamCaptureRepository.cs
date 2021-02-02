using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class WebCamCaptureRepository : Repository<SnapshotImage, int, DevTrackContext>, IWebCamCaptureRepository
    {
        public WebCamCaptureRepository(DevTrackContext WebCanContext) : base(WebCanContext)
        {

        }
    }
}
