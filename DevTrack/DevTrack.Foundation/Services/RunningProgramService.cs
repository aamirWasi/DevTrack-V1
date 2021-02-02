using DevTrack.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EO = DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class RunningProgramService : IRunningProgramService
    {
        private readonly IRunningProgramUnitOfWork _runningProgramUnitOfWork;

        public RunningProgramService(IRunningProgramUnitOfWork runningProgramUnitOfWork)
        {
            _runningProgramUnitOfWork = runningProgramUnitOfWork;
        }

        public void AddCurrentlyRunningPrograms()
        {
            var RunningApps = GetRunningProgramsList();

            var RunningAppsEntity = new EO.RunningProgram
            {
                DateTime = DateTime.Now,
                RunningApplications = RunningApps,
            };

            _runningProgramUnitOfWork.RunningProgramRepository.Add(RunningAppsEntity);
            _runningProgramUnitOfWork.Save();
        }

        private List<string> GetRunningProgramsList()
        {
            var Applist = new List<string>();

            Process[] procList = Process.GetProcesses();
            for (int i = 0; i < procList.Length; i++)
            {
                if (procList[i].MainWindowHandle != IntPtr.Zero)
                {
                    Applist.Add(procList[i].ProcessName);
                    //var ProgramsList = procList[i].ProcessName;
                }
            }
            return Applist;
        }
    }
}
