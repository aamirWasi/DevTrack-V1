using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

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
