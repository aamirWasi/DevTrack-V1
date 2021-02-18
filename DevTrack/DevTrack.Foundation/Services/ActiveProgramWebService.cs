using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class ActiveProgramWebService : IActiveProgramWebService
    {
        
        private readonly IActiveProgramWebUnitOfWork _activeProgramWebUnitOf;

        public ActiveProgramWebService(IActiveProgramWebUnitOfWork activeProgramWebUnit)
        {
            _activeProgramWebUnitOf = activeProgramWebUnit;
        }

        public void SaveActiveProgramWebDb(ActiveProgram program)
        {
            if (program == null)
            {
                throw new InvalidOperationException("program information is  missing");
            }
            else
            {
                _activeProgramWebUnitOf.ActiveProgramWebRepository.Add(program);
                _activeProgramWebUnitOf.Save();
            }
        }
    }
    }
}
