using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class ActiveProgramService : IActiveProgramService
    {
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        private readonly IActiveProgramUnitOfWork _activeProgramUnitOfWork;

        public ActiveProgramService(IActiveProgramUnitOfWork activeProgramUnitOfWork)
        {
            _activeProgramUnitOfWork = activeProgramUnitOfWork;
        }

        public void SaveActiveProgram()
        {
            var programName = GetActiveProgramName();
            
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

        private string GetActiveProgramName()
        {
            var programName = "";
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                programName = Buff.ToString();
                //var idWindowLabel = handle.ToString();
            }

            return programName;
        }
    }
}
