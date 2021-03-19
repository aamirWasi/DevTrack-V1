using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DevTrack.Foundation.Adapters;

namespace DevTrack.Foundation.Adapters
{
    public class ActiveProgramAdapter : IActiveProgramAdapter
    {

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        public string GetActiveProgramName()
        {
            var programName = "";
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                programName = Buff.ToString();
            }

            return programName;
        }
    }
}
