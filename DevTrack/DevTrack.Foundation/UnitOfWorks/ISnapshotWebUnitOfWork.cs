using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface ISnapshotWebUnitOfWork : IUnitOfWork
    {
        ISnapshotWebRepository SnapshotWebRepository { get; set; }
    }
}
