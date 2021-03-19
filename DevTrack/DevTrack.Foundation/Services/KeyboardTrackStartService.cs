using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackStartService : IKeyboardTrackStartService
    {
        private static KeyboardBusinessObject _keyboardBusiness;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private bool _isFirst = true;
        public KeyboardTrackStartService()
        {
            _keyboardBusiness = new KeyboardBusinessObject();
        }

        public void KeyboardTrack()
        {
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        public Keyboard KeyboardEntity()
        {
            if (_isFirst)
            {
                _isFirst = false;
                return null;
            }
            var entity = _keyboardBusiness.ConvertToEntity(_keyboardBusiness);
            _keyboardBusiness = new KeyboardBusinessObject();
            return entity;
        }
        
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule;
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule?.ModuleName), 0);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                var key = Convert.ToString((Keys)Marshal.ReadInt32(lParam));
                _keyboardBusiness.TotalKeyHits++;
                switch (key)
                {
                    #region Alphabet Case


                    case "A": _keyboardBusiness.A++; break;
                    case "B": _keyboardBusiness.B++; break;
                    case "C": _keyboardBusiness.C++; break;
                    case "D": _keyboardBusiness.D++; break;
                    case "E": _keyboardBusiness.E++; break;
                    case "F": _keyboardBusiness.F++; break;
                    case "G": _keyboardBusiness.G++; break;
                    case "H": _keyboardBusiness.H++; break;
                    case "I": _keyboardBusiness.I++; break;
                    case "J": _keyboardBusiness.J++; break;
                    case "K": _keyboardBusiness.K++; break;
                    case "L": _keyboardBusiness.L++; break;
                    case "M": _keyboardBusiness.M++; break;
                    case "N": _keyboardBusiness.N++; break;
                    case "O": _keyboardBusiness.O++; break;
                    case "P": _keyboardBusiness.P++; break;
                    case "Q": _keyboardBusiness.Q++; break;
                    case "R": _keyboardBusiness.R++; break;
                    case "S": _keyboardBusiness.S++; break;
                    case "T": _keyboardBusiness.T++; break;
                    case "U": _keyboardBusiness.U++; break;
                    case "V": _keyboardBusiness.V++; break;
                    case "W": _keyboardBusiness.W++; break;
                    case "X": _keyboardBusiness.X++; break;
                    case "Y": _keyboardBusiness.Y++; break;
                    case "Z": _keyboardBusiness.Z++; break;

                    #endregion

                    #region NumPad Case

                    case "NumPad0": _keyboardBusiness.NumPad0++; break;
                    case "NumPad1": _keyboardBusiness.NumPad1++; break;
                    case "NumPad2": _keyboardBusiness.NumPad2++; break;
                    case "NumPad3": _keyboardBusiness.NumPad3++; break;
                    case "NumPad4": _keyboardBusiness.NumPad4++; break;
                    case "NumPad5": _keyboardBusiness.NumPad5++; break;
                    case "NumPad6": _keyboardBusiness.NumPad6++; break;
                    case "NumPad7": _keyboardBusiness.NumPad7++; break;
                    case "NumPad8": _keyboardBusiness.NumPad8++; break;
                    case "NumPad9": _keyboardBusiness.NumPad9++; break;
                    #endregion

                    #region Functional Case

                    case "Escape": _keyboardBusiness.Escape++; break;
                    case "F1": _keyboardBusiness.F1++; break;
                    case "F2": _keyboardBusiness.F2++; break;
                    case "F3": _keyboardBusiness.F3++; break;
                    case "F4": _keyboardBusiness.F4++; break;
                    case "F5": _keyboardBusiness.F5++; break;
                    case "F6": _keyboardBusiness.F6++; break;
                    case "F7": _keyboardBusiness.F7++; break;
                    case "F8": _keyboardBusiness.F8++; break;
                    case "F9": _keyboardBusiness.F9++; break;
                    case "F10": _keyboardBusiness.F10++; break;
                    case "F11": _keyboardBusiness.F11++; break;
                    case "F12": _keyboardBusiness.F12++; break;


                    #endregion

                    #region TopNumPadRow Case


                    case "Oemtilde": _keyboardBusiness.Oemtilde++; break;
                    case "D1": _keyboardBusiness.D1++; break;
                    case "D2": _keyboardBusiness.D2++; break;
                    case "D3": _keyboardBusiness.D3++; break;
                    case "D4": _keyboardBusiness.D4++; break;
                    case "D5": _keyboardBusiness.D5++; break;
                    case "D6": _keyboardBusiness.D6++; break;
                    case "D7": _keyboardBusiness.D7++; break;
                    case "D8": _keyboardBusiness.D8++; break;
                    case "D9": _keyboardBusiness.D9++; break;
                    case "D0": _keyboardBusiness.D0++; break;
                    case "OemMinus": _keyboardBusiness.OemMinus++; break;
                    case "Oemplus": _keyboardBusiness.Oemplus++; break;
                    case "Oem5": _keyboardBusiness.Oem5++; break;
                    case "Back": _keyboardBusiness.Back++; break;

                    #endregion

                    #region Typing Case

                    case "Tab": _keyboardBusiness.Tab++; break;
                    case "OemOpenBrackets": _keyboardBusiness.OemOpenBrackets++; break;
                    case "Oem6": _keyboardBusiness.Oem6++; break;

                    case "Capital": _keyboardBusiness.Capital++; break;
                    case "Oem1": _keyboardBusiness.Oem1++; break;
                    case "Oem7": _keyboardBusiness.Oem7++; break;
                    case "Return": _keyboardBusiness.Enter++; break;

                    case "LShiftKey": _keyboardBusiness.LShiftKey++; break;
                    case "Oemcomma": _keyboardBusiness.Oemcomma++; break;
                    case "OemPeriod": _keyboardBusiness.OemPeriod++; break;
                    case "OemQuestion": _keyboardBusiness.OemQuestion++; break;
                    case "RShiftKey": _keyboardBusiness.RShiftKey++; break;

                    #endregion

                    #region Control Key Case

                    case "LControlKey": _keyboardBusiness.LControlKey++; break;
                    case "LWin": _keyboardBusiness.LWin++; break;
                    case "Space": _keyboardBusiness.Space++; break;
                    case "RWin": _keyboardBusiness.RWin++; break;
                    case "Apps": _keyboardBusiness.Apps++; break;
                    case "RControlKey": _keyboardBusiness.RControlKey++; break;

                    #endregion

                    #region NavigationKey

                    case "PrintScreen": _keyboardBusiness.PrintScreen++; break;
                    case "Scroll": _keyboardBusiness.Scroll++; break;
                    case "Pause": _keyboardBusiness.Pause++; break;

                    case "Insert": _keyboardBusiness.Insert++; break;
                    case "Home": _keyboardBusiness.Home++; break;
                    case "PageUp": _keyboardBusiness.PageUp++; break;
                    case "Delete": _keyboardBusiness.Delete++; break;
                    case "End": _keyboardBusiness.End++; break;
                    case "Next": _keyboardBusiness.Next++; break;

                    #endregion

                    #region Arrow Key


                    case "Left": _keyboardBusiness.Left++; break;
                    case "Up": _keyboardBusiness.Up++; break;
                    case "Right": _keyboardBusiness.Right++; break;
                    case "Down": _keyboardBusiness.Down++; break;

                    #endregion

                    #region Arithmatic Case

                    case "Decimal": _keyboardBusiness.Decimal++; break;
                    case "Add": _keyboardBusiness.Add++; break;
                    case "Subtract": _keyboardBusiness.Subtract++; break;
                    case "Multiply": _keyboardBusiness.Multiply++; break;
                    case "Divide": _keyboardBusiness.Divide++; break;
                    case "NumLock": _keyboardBusiness.NumLock++; break;

                        #endregion
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}