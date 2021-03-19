using Autofac;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EO = DevTrack.Foundation.Entities;

namespace DevTrack.API.Models
{
    public class RunningProgramModel
    {
        public string RunningApplications { get; set; }
        public DateTime RunningApplicationsDateTime { get; set; }

        private IRunningProgramWebService _runningProgramWebService;
        public RunningProgramModel()
        {
            _runningProgramWebService = Startup.AutofacContainer.Resolve<IRunningProgramWebService>();
        }

        public void SaveRunningPrograms()
        {
            if (!string.IsNullOrWhiteSpace(RunningApplications))
            {
                _runningProgramWebService.AddRunningProgramsWebDb(new EO.RunningProgram
                {
                    RunningApplications = RunningApplications,
                    RunningApplicationsDateTime = RunningApplicationsDateTime,
                });
            }
        }
    }
}
