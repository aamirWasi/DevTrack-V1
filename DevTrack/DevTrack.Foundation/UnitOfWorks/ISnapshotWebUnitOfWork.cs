using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface ISnapshotWebUnitOfWork : IUnitOfWork
    {
        ISnapshotWebRepository SnapshotWebRepository { get; set; }
    }
}
