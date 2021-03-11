using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DevTrack.Foundation.Adapters
{
    public class RunningProgramAdapter : IRunningProgramAdapter
    {
        public string GetRunningPrograms()
        {
            return string.Join(",", GetRunningProgramsList().ToArray());
        }

        public List<string> GetRunningProgramsList()
        {
            var applist = new List<string>();

            var procList = Process.GetProcesses();
            for (int i = 0; i < procList.Length; i++)
            {
                if (procList[i].MainWindowHandle != IntPtr.Zero)
                {
                    applist.Add(procList[i].ProcessName);
                    //var ProgramsList = procList[i].ProcessName;
                }
            }

            return applist;
        }
    }
}
