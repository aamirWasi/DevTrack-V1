using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class RunningProgramUnitOfWork : UnitOfWork, IRunningProgramUnitOfWork
    {
        public IRunningProgramRepository RunningProgramRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RunningProgramUnitOfWork(DevTrackContext devTrackContext, IRunningProgramRepository runningProgramRepository)
            : base(devTrackContext)
        {
            RunningProgramRepository = runningProgramRepository;
        }
    }
}
