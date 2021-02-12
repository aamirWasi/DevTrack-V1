using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Adapters;
using EO = DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class RunningProgramService : IRunningProgramService
    {
        private readonly IRunningProgramUnitOfWork _runningProgramUnitOfWork;
        private readonly IRunningProgramAdapter _runningProgramAdpater;

        public RunningProgramService(IRunningProgramUnitOfWork runningProgramUnitOfWork,IRunningProgramAdapter runningProgramAdapter)
        {
            _runningProgramUnitOfWork = runningProgramUnitOfWork;
            _runningProgramAdpater = runningProgramAdapter;
        }

        public void AddCurrentlyRunningPrograms()
        {
            var runningApps = _runningProgramAdpater.GetRunningPrograms();

            if (string.IsNullOrWhiteSpace(runningApps))
                throw new InvalidOperationException("Program name is not provided");

            var runningAppsEntity = new EO.RunningProgram
            {
                RunningApplications = runningApps,
                RunningApplicationsDateTime = DateTime.Now,
            };

            _runningProgramUnitOfWork.RunningProgramRepository.Add(runningAppsEntity);
            _runningProgramUnitOfWork.Save();
        }
    }
}
