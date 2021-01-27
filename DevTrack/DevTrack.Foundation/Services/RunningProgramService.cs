using System;
using System.Diagnostics;

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
                    var ProgramsList = procList[i].ProcessName;
                    //Console.WriteLine(procList[i].ProcessName);
                }
            }
        }
    }
}
