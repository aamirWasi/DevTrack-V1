using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public interface ISnapshotRepository : IRepository<SnapshotImage, int,ScreenCaptureContext>
    {

    }
}
