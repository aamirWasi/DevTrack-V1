using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class SnapshotWebRepository : Repository<SnapshotImage, int, DevTrackWebContext>, ISnapshotWebRepository
    {
        public SnapshotWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}
