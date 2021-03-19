using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories.Interfaces
{
    public interface IWebCamCaptureRepository : IRepository<WebCamCaptureImage, int, DevTrackContext>
    {

    }
}
