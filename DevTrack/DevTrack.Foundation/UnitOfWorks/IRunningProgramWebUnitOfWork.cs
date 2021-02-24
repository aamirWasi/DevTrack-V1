using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IRunningProgramWebUnitOfWork : IUnitOfWork
    {
        IRunningProgramWebRepository RunningProgramWebRepository { get; set; }
    }
}
