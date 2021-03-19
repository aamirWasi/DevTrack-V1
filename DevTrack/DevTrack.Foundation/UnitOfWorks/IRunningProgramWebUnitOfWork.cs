using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IRunningProgramWebUnitOfWork : IUnitOfWork
    {
        IRunningProgramWebRepository RunningProgramWebRepository { get; set; }
    }
}
