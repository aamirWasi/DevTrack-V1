using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class SnapshotWebUnitOfWork : UnitOfWork, ISnapshotWebUnitOfWork
    {
        public SnapshotWebUnitOfWork(DevTrackWebContext devTrackWebContext, ISnapshotWebRepository snapshotWebRepository) : base(devTrackWebContext)
        {
            SnapshotWebRepository = snapshotWebRepository;
        }

        public ISnapshotWebRepository SnapshotWebRepository { get; set; }
    }
}
