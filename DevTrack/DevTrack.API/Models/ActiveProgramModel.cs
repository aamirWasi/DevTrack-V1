using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrack.API.Models
{
    public class ActiveProgramModel
    {
        public string ProgramName { get; set; }
        public DateTime ProgramTime { get; set; }

        private IActiveProgramWebService _activeProgramWebService;

        public ActiveProgramModel()
        {
            _activeProgramWebService = Startup.AutofacContainer.Resolve<IActiveProgramWebService>();
        }

        public void SaveActiveProgram()
        {
            if (!string.IsNullOrWhiteSpace(ProgramName))
            {
                
                _activeProgramWebService.SaveActiveProgramWebDb(new ActiveProgram
                {
                    ProgramName = ProgramName,
                    ProgramTime = ProgramTime
                });
            }
        }
    }
}
