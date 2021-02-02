using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IRunningProgramUnitOfWork : IUnitOfWork
    {
        IRunningProgramRepository RunningProgramRepository { get; set; }
    }
}
