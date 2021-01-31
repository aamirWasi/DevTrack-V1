using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class ActiveWindowsService : IActiveWindowsService
    {
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        public string windowLable;

        public string GetActiveWindow()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                windowLable = Buff.ToString();
                var idWindowLabel = handle.ToString();
            }

            return windowLable;
        }
    }
}
