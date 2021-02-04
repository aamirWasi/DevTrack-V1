using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using System;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class RunningProgramUnitOfWork : UnitOfWork, IRunningProgramUnitOfWork
    {
        public IRunningProgramRepository RunningProgramRepository { get; set; }
        public RunningProgramUnitOfWork(DevTrackContext devTrackContext, IRunningProgramRepository runningProgramRepository)
            : base(devTrackContext)
        {
            RunningProgramRepository = runningProgramRepository;
        }
    }
}
