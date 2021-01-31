using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface ISnapshotUnitOfWork : IUnitOfWork
    {
        ISnapshotRepository SnapshotRepository { get; set; }
    }
}
