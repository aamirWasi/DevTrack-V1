using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IRunningProgramWebUnitOfWork : IUnitOfWork
    {
        IRunningProgramWebRepository RunningProgramWebRepository { get; set; }
    }
}
