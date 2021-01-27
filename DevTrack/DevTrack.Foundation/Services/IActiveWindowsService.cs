using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerServiceDemo
{
    public interface IActiveWindowsService
    {
       public string GetActiveWindow();
    }
}
