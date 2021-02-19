using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class RunningProgramWebUnitOfWork : UnitOfWork, IRunningProgramWebUnitOfWork
    {
        public IRunningProgramWebRepository RunningProgramWebRepository { get; set; }

        public RunningProgramWebUnitOfWork(DevTrackWebContext devTrackWebContext, IRunningProgramWebRepository runningProgramWebRepository) : base(devTrackWebContext)
        {
            RunningProgramWebRepository = runningProgramWebRepository;
        }

    }
}
