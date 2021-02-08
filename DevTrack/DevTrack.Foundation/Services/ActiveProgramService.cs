using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DevTrack.Foundation.Adapters;

namespace DevTrack.Foundation.Services
{
    public class ActiveProgramService : IActiveProgramService
    {

        private readonly IActiveProgramUnitOfWork _activeProgramUnitOfWork;
        private readonly IActiveProgramAdapter _activeProgramAdapter;

        public ActiveProgramService(IActiveProgramUnitOfWork activeProgramUnitOfWork,IActiveProgramAdapter activeProgramAdapter)
        {
            _activeProgramUnitOfWork = activeProgramUnitOfWork;
            _activeProgramAdapter = activeProgramAdapter;
        }

        public void SaveActiveProgram()
        {
            var programName = _activeProgramAdapter.GetActiveProgramName();
            
            if (string.IsNullOrWhiteSpace(programName))
                throw new InvalidOperationException("Program name is missing");

            var activeProgram = new ActiveProgram
            {
                ProgramName = programName,
                ProgramTime = DateTime.Now
            };

            _activeProgramUnitOfWork.ActiveProgramRepository.Add(activeProgram);
            _activeProgramUnitOfWork.Save();
        }

        
    }
}
