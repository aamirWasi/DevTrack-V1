using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System;

namespace DevTrack.Foundation.Services
{
    public class RunningProgramWebService : IRunningProgramWebService
    {
        private readonly IRunningProgramWebUnitOfWork _runningProgramWebUnitOfWork;
        public RunningProgramWebService(IRunningProgramWebUnitOfWork runningProgramWebUnitOfWork)
        {
            _runningProgramWebUnitOfWork = runningProgramWebUnitOfWork;
        }

        public void AddRunningProgramsWebDb(RunningProgram program)
        {
            if (program == null)
            {
                throw new InvalidOperationException("Running Prgrams are not found");
            }
            else
            {
                _runningProgramWebUnitOfWork.RunningProgramWebRepository.Add(program);
                _runningProgramWebUnitOfWork.Save();
            }
        }
    }
}
