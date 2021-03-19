using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IRunningProgramUnitOfWork : IUnitOfWork
    {
        IRunningProgramRepository RunningProgramRepository { get; set; }
    }
}
