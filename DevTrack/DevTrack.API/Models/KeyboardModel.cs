using Autofac;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.API.Models
{
    public class KeyboardModel
    {
        private readonly IKeyboardWebService _keyboardWeb;

        public KeyboardModel()
        {
            _keyboardWeb = Startup.AutofacContainer.Resolve<IKeyboardWebService>();
        }

        public int TotalKeyHits { get; set; }

        #region Functional Keys
        public int Escape { get; set; }
        public int F1 { get; set; }
        public int F2 { get; set; }
        public int F3 { get; set; }
        public int F4 { get; set; }
        public int F5 { get; set; }
        public int F6 { get; set; }
        public int F7 { get; set; }
        public int F8 { get; set; }
        public int F9 { get; set; }
        public int F10 { get; set; }
        public int F11 { get; set; }
        public int F12 { get; set; }
        #endregion

        #region Numeric keypad
        public int NumPad0 { get; set; }
        public int NumPad1 { get; set; }
        public int NumPad2 { get; set; }
        public int NumPad3 { get; set; }
        public int NumPad4 { get; set; }
        public int NumPad5 { get; set; }
        public int NumPad6 { get; set; }
        public int NumPad7 { get; set; }
        public int NumPad8 { get; set; }
        public int NumPad9 { get; set; }

        public int Decimal { get; set; }
        public int Add { get; set; }
        public int Subtract { get; set; }
        public int Multiply { get; set; }
        public int Divide { get; set; }
        public int NumLock { get; set; }
        #endregion

        #region TopNumPadRow
        public int Oemtilde { get; set; }
        public int D1 { get; set; }
        public int D2 { get; set; }
        public int D3 { get; set; }
        public int D4 { get; set; }
        public int D5 { get; set; }
        public int D6 { get; set; }
        public int D7 { get; set; }
        public int D8 { get; set; }
        public int D9 { get; set; }
        public int D0 { get; set; }
        public int OemMinus { get; set; }
        public int Oemplus { get; set; }
        public int Oem5 { get; set; }
        public int Back { get; set; }

        #endregion

        #region Typing Key

        public int Tab { get; set; }
        public int OemOpenBrackets { get; set; }
        public int Oem6 { get; set; }

        public int Capital { get; set; }
        public int Oem1 { get; set; }
        public int Oem7 { get; set; }
        public int Enter { get; set; }

        public int LShiftKey { get; set; }
        public int Oemcomma { get; set; }
        public int OemPeriod { get; set; }
        public int OemQuestion { get; set; }
        public int RShiftKey { get; set; }
        #endregion

        #region Control keys
        public int LControlKey { get; set; }
        public int LWin { get; set; }
        public int Space { get; set; }
        public int RWin { get; set; }
        public int Apps { get; set; }
        public int RControlKey { get; set; }
        #endregion

        #region Feature Key
        public int PrintScreen { get; set; }
        public int Scroll { get; set; }
        public int Pause { get; set; }
        #endregion

        #region Navigation keys
        public int Insert { get; set; }
        public int Home { get; set; }
        public int PageUp { get; set; }
        public int Delete { get; set; }
        public int End { get; set; }
        public int Next { get; set; }
        #endregion

        #region Arrow Key
        public int Left { get; set; }
        public int Up { get; set; }
        public int Right { get; set; }
        public int Down { get; set; }
        #endregion

        #region Alphabet Key

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int K { get; set; }
        public int L { get; set; }
        public int M { get; set; }
        public int N { get; set; }
        public int O { get; set; }
        public int P { get; set; }
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        public int U { get; set; }
        public int V { get; set; }
        public int W { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        #endregion

        public void SaveKeyboardIntoWeb(KeyboardModel model)
        {
            var keyboard = new KeyboardBusinessObject().ConvertToEntity(new KeyboardBusinessObject
            {
                TotalKeyHits = model.TotalKeyHits,
                A = model.A,
                B = model.B,
                C = model.C,
                D = model.D,
                E = model.E,
                F = model.F,
                G = model.G,
                H = model.H,
                I = model.I,
                J = model.J,
                K = model.K,
                L = model.L,
                M = model.M,
                N = model.N,
                O = model.O,
                P = model.P,
                Q = model.Q,
                R = model.R,
                S = model.S,
                T = model.T,
                U = model.U,
                V = model.V,
                W = model.W,
                X = model.X,
                Y = model.Y,
                Z = model.Z,

                NumPad0 = model.NumPad0,
                NumPad1 = model.NumPad1,
                NumPad2 = model.NumPad2,
                NumPad3 = model.NumPad3,
                NumPad4 = model.NumPad4,
                NumPad5 = model.NumPad5,
                NumPad6 = model.NumPad6,
                NumPad7 = model.NumPad7,
                NumPad8 = model.NumPad8,
                NumPad9 = model.NumPad9,

                Escape = model.Escape,
                F1 = model.F1,
                F2 = model.F2,
                F3 = model.F3,
                F4 = model.F4,
                F5 = model.F5,
                F6 = model.F6,
                F7 = model.F7,
                F8 = model.F8,
                F9 = model.F9,
                F10 = model.F10,
                F11 = model.F11,
                F12 = model.F12,

                Oemtilde = model.Oemtilde,
                D1 = model.D1,
                D2 = model.D2,
                D3 = model.D3,
                D4 = model.D4,
                D5 = model.D5,
                D6 = model.D6,
                D7 = model.D7,
                D8 = model.D8,
                D9 = model.D9,
                D0 = model.D0,
                OemMinus = model.OemMinus,
                Oemplus = model.Oemplus,
                Oem5 = model.Oem5,
                Back = model.Back,

                Tab = model.Tab,
                OemOpenBrackets = model.OemOpenBrackets,
                Oem6 = model.Oem6,

                Capital = model.Capital,
                Oem1 = model.Oem1,
                Oem7 = model.Oem7,
                Enter = model.Enter,

                LShiftKey = model.LShiftKey,
                Oemcomma = model.Oemcomma,
                OemPeriod = model.OemPeriod,
                OemQuestion = model.OemQuestion,
                RShiftKey = model.RShiftKey,

                LControlKey = model.LControlKey,
                LWin = model.LWin,
                Space = model.Space,
                RWin = model.RWin,
                Apps = model.Apps,
                RControlKey = model.RControlKey,

                PrintScreen = model.PrintScreen,
                Scroll = model.Scroll,
                Pause = model.Pause,

                Insert = model.Insert,
                Home = model.Home,
                PageUp = model.PageUp,
                Delete = model.Delete,
                End = model.End,
                Next = model.Next,

                Left = model.Left,
                Up = model.Up,
                Right = model.Right,
                Down = model.Down,

                Decimal = model.Decimal,
                Add = model.Add,
                Subtract = model.Subtract,
                Multiply = model.Multiply,
                Divide = model.Divide,
                NumLock = model.NumLock
            });
            _keyboardWeb.SaveKeyboardIntoWeb(keyboard);
        }
    }
}
