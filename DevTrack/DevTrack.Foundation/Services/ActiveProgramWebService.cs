using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class ActiveProgramWebService : IActiveProgramWebService
    {
        
        private readonly IActiveProgramWebUnitOfWork _activeProgramWebUnitOfWork;

        public ActiveProgramWebService(IActiveProgramWebUnitOfWork activeProgramWebUnit)
        {
            _activeProgramWebUnitOfWork = activeProgramWebUnit;
        }

        public void SaveActiveProgramWebDb(ActiveProgram program)
        {
            if (program == null)
            {
                throw new InvalidOperationException("program information is  missing");
            }
            else
            {
                _activeProgramWebUnitOfWork.ActiveProgramWebRepository.Add(program);
                _activeProgramWebUnitOfWork.Save();
            }
        }
    
    }
}
