using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private static KeyboardBusinessObject _keyboardBusiness;
        public KeyboardTrackService(IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork)
        {
            _keyboardTrackUnitOfWork = keyboardTrackUnitOfWork;
            _keyboardBusiness = new KeyboardBusinessObject();
        }
        public void KeyboardTrack()
        {
            Start();
        }

        public void TrackSave()
        {
            var keyboardEntity = _keyboardBusiness.ConvertTOEntity(_keyboardBusiness);
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static void Start()
        {
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule;
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule?.ModuleName), 0);
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                var key = Convert.ToString((Keys)Marshal.ReadInt32(lParam));

                switch (key)
                {
                    #region Alphabet Case


                    case "A": _keyboardBusiness.A++; _keyboardBusiness.TotalKeyHits++; break;
                    case "B": _keyboardBusiness.B++; _keyboardBusiness.TotalKeyHits++; break;
                    case "C": _keyboardBusiness.C++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D": _keyboardBusiness.D++; _keyboardBusiness.TotalKeyHits++; break;
                    case "E": _keyboardBusiness.E++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F": _keyboardBusiness.F++; _keyboardBusiness.TotalKeyHits++; break;
                    case "G": _keyboardBusiness.G++; _keyboardBusiness.TotalKeyHits++; break;
                    case "H": _keyboardBusiness.H++; _keyboardBusiness.TotalKeyHits++; break;
                    case "I": _keyboardBusiness.I++; _keyboardBusiness.TotalKeyHits++; break;
                    case "J": _keyboardBusiness.J++; _keyboardBusiness.TotalKeyHits++; break;
                    case "K": _keyboardBusiness.K++; _keyboardBusiness.TotalKeyHits++; break;
                    case "L": _keyboardBusiness.L++; _keyboardBusiness.TotalKeyHits++; break;
                    case "M": _keyboardBusiness.M++; _keyboardBusiness.TotalKeyHits++; break;
                    case "N": _keyboardBusiness.N++; _keyboardBusiness.TotalKeyHits++; break;
                    case "O": _keyboardBusiness.O++; _keyboardBusiness.TotalKeyHits++; break;
                    case "P": _keyboardBusiness.P++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Q": _keyboardBusiness.Q++; _keyboardBusiness.TotalKeyHits++; break;
                    case "R": _keyboardBusiness.R++; _keyboardBusiness.TotalKeyHits++; break;
                    case "S": _keyboardBusiness.S++; _keyboardBusiness.TotalKeyHits++; break;
                    case "T": _keyboardBusiness.T++; _keyboardBusiness.TotalKeyHits++; break;
                    case "U": _keyboardBusiness.U++; _keyboardBusiness.TotalKeyHits++; break;
                    case "V": _keyboardBusiness.V++; _keyboardBusiness.TotalKeyHits++; break;
                    case "W": _keyboardBusiness.W++; _keyboardBusiness.TotalKeyHits++; break;
                    case "X": _keyboardBusiness.X++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Y": _keyboardBusiness.Y++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Z": _keyboardBusiness.Z++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion

                    #region NumPad Case

                    case "NumPad0": _keyboardBusiness.NumPad0++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad1": _keyboardBusiness.NumPad1++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad2": _keyboardBusiness.NumPad2++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad3": _keyboardBusiness.NumPad3++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad4": _keyboardBusiness.NumPad4++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad5": _keyboardBusiness.NumPad5++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad6": _keyboardBusiness.NumPad6++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad7": _keyboardBusiness.NumPad7++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad8": _keyboardBusiness.NumPad8++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumPad9": _keyboardBusiness.NumPad9++; _keyboardBusiness.TotalKeyHits++; break;
                    #endregion

                    #region Functional Case

                    case "Escape": _keyboardBusiness.Escape++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F1": _keyboardBusiness.F1++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F2": _keyboardBusiness.F2++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F3": _keyboardBusiness.F3++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F4": _keyboardBusiness.F4++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F5": _keyboardBusiness.F5++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F6": _keyboardBusiness.F6++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F7": _keyboardBusiness.F7++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F8": _keyboardBusiness.F8++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F9": _keyboardBusiness.F9++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F10": _keyboardBusiness.F10++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F11": _keyboardBusiness.F11++; _keyboardBusiness.TotalKeyHits++; break;
                    case "F12": _keyboardBusiness.F12++; _keyboardBusiness.TotalKeyHits++; break;


                    #endregion

                    #region TopNumPadRow Case


                    case "Oemtilde": _keyboardBusiness.Oemtilde++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D1": _keyboardBusiness.D1++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D2": _keyboardBusiness.D2++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D3": _keyboardBusiness.D3++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D4": _keyboardBusiness.D4++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D5": _keyboardBusiness.D5++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D6": _keyboardBusiness.D6++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D7": _keyboardBusiness.D7++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D8": _keyboardBusiness.D8++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D9": _keyboardBusiness.D9++; _keyboardBusiness.TotalKeyHits++; break;
                    case "D0": _keyboardBusiness.D0++; _keyboardBusiness.TotalKeyHits++; break;
                    case "OemMinus": _keyboardBusiness.OemMinus++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oemplus": _keyboardBusiness.Oemplus++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oem5": _keyboardBusiness.Oem5++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Back": _keyboardBusiness.Back++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion

                    #region Typing Case

                    case "Tab": _keyboardBusiness.Tab++; _keyboardBusiness.TotalKeyHits++; break;
                    case "OemOpenBrackets": _keyboardBusiness.OemOpenBrackets++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oem6": _keyboardBusiness.Oem6++; _keyboardBusiness.TotalKeyHits++; break;

                    case "Capital": _keyboardBusiness.Capital++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oem1": _keyboardBusiness.Oem1++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oem7": _keyboardBusiness.Oem7++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Return": _keyboardBusiness.Enter++; _keyboardBusiness.TotalKeyHits++; break;

                    case "LShiftKey": _keyboardBusiness.LShiftKey++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Oemcomma": _keyboardBusiness.Oemcomma++; _keyboardBusiness.TotalKeyHits++; break;
                    case "OemPeriod": _keyboardBusiness.OemPeriod++; _keyboardBusiness.TotalKeyHits++; break;
                    case "OemQuestion": _keyboardBusiness.OemQuestion++; _keyboardBusiness.TotalKeyHits++; break;
                    case "RShiftKey": _keyboardBusiness.RShiftKey++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion

                    #region Control Key Case

                    case "LControlKey": _keyboardBusiness.LControlKey++; _keyboardBusiness.TotalKeyHits++; break;
                    case "LWin": _keyboardBusiness.LWin++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Space": _keyboardBusiness.Space++; _keyboardBusiness.TotalKeyHits++; break;
                    case "RWin": _keyboardBusiness.RWin++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Apps": _keyboardBusiness.Apps++; _keyboardBusiness.TotalKeyHits++; break;
                    case "RControlKey": _keyboardBusiness.RControlKey++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion

                    #region NavigationKey

                    case "PrintScreen": _keyboardBusiness.PrintScreen++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Scroll": _keyboardBusiness.Scroll++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Pause": _keyboardBusiness.Pause++; _keyboardBusiness.TotalKeyHits++; break;

                    case "Insert": _keyboardBusiness.Insert++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Home": _keyboardBusiness.Home++; _keyboardBusiness.TotalKeyHits++; break;
                    case "PageUp": _keyboardBusiness.PageUp++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Delete": _keyboardBusiness.Delete++; _keyboardBusiness.TotalKeyHits++; break;
                    case "End": _keyboardBusiness.End++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Next": _keyboardBusiness.Next++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion

                    #region Arrow Key


                    case "Left": _keyboardBusiness.Left++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Up": _keyboardBusiness.Up++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Right": _keyboardBusiness.Right++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Down": _keyboardBusiness.Down++; _keyboardBusiness.TotalKeyHits++; break;

                        #endregion

                    #region Arithmatic Case

                    case "Decimal": _keyboardBusiness.Decimal++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Add": _keyboardBusiness.Add++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Subtract": _keyboardBusiness.Subtract++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Multiply": _keyboardBusiness.Multiply++; _keyboardBusiness.TotalKeyHits++; break;
                    case "Divide": _keyboardBusiness.Divide++; _keyboardBusiness.TotalKeyHits++; break;
                    case "NumLock": _keyboardBusiness.NumLock++; _keyboardBusiness.TotalKeyHits++; break;

                    #endregion
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
