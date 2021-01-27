using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class RunningProgramService : IRunningProgramService
    {
        public void GetProcesses()
        {
            Process[] procList = Process.GetProcesses();

            for (int i = 0; i < procList.Length; i++)
            {
                if (procList[i].MainWindowHandle != IntPtr.Zero)
                {
                    Console.WriteLine(procList[i].ProcessName);
                }
            }
        }
    }
}
