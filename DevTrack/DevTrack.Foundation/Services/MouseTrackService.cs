using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DevTrack.Foundation.Services
{
    public class MouseTrackService : IMouseTrackService
    {
        public void MouseTrack()
        {
            Start();
        }
        private static readonly LowLevelMouseProc _proc = HookCallback;
        protected static IntPtr _hookId = IntPtr.Zero;
        protected const int WM_MOUSE_LL = 14;
        protected const int WM_LBUTTONDOWN = 0x201;
        protected const int WM_RBUTTONDOWN = 0x204;
        protected const int WM_MBUTTONDOWN = 0x207;
        protected const int WM_LBUTTONDBLCLK = 0x203;
        protected const int WM_RBUTTONDBLCLK = 0x206;
        protected const int WM_MBUTTONDBLCLK = 0x209;
        protected const int WM_MOUSEWHEEL = 0x020A;

        public static void Start()
        {
            _hookId = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookId);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule;
            return SetWindowsHookEx(WM_MOUSE_LL, proc,
                GetModuleHandle(curModule?.ModuleName), 0);
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            switch (wParam.ToInt32())
            {
                case WM_LBUTTONDOWN:
                    {
                        Console.WriteLine("Left Button Clicked");
                        break;
                    }
                case WM_LBUTTONDBLCLK:
                    {
                        Console.WriteLine("Left Button Double sClicked");
                        break;
                    }
                case WM_RBUTTONDOWN:
                    {
                        Console.WriteLine("Left Button Double Clicked");
                        break;
                    }
                case WM_RBUTTONDBLCLK:
                    {
                        Console.WriteLine("Right Button Double Clicked");
                        break;
                    }
                case WM_MBUTTONDOWN:
                    {
                        Console.WriteLine("Middle Button Clicked");
                        break;
                    }
                case WM_MOUSEWHEEL:
                    {
                        Console.WriteLine("Mouse Wheel Button");
                        break;
                    }
            }
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
