using EO = DevTrack.Foundation.Entities;


namespace DevTrack.Foundation.BusinessObjects
{
    public class KeyboardBusinessObject
    {
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

        public EO.Keyboard ConvertToEntity(KeyboardBusinessObject keyboardBusiness)
        {
            return new EO.Keyboard()
            {
                TotalKeyHits = keyboardBusiness.TotalKeyHits,
                A = keyboardBusiness.A,
                B = keyboardBusiness.B,
                C = keyboardBusiness.C,
                D = keyboardBusiness.D,
                E = keyboardBusiness.E,
                F = keyboardBusiness.F,
                G = keyboardBusiness.G,
                H = keyboardBusiness.H,
                I = keyboardBusiness.I,
                J = keyboardBusiness.J,
                K = keyboardBusiness.K,
                L = keyboardBusiness.L,
                M = keyboardBusiness.M,
                N = keyboardBusiness.N,
                O = keyboardBusiness.O,
                P = keyboardBusiness.P,
                Q = keyboardBusiness.Q,
                R = keyboardBusiness.R,
                S = keyboardBusiness.S,
                T = keyboardBusiness.T,
                U = keyboardBusiness.U,
                V = keyboardBusiness.V,
                W = keyboardBusiness.W,
                X = keyboardBusiness.X,
                Y = keyboardBusiness.Y,
                Z = keyboardBusiness.Z,

                NumPad0 = keyboardBusiness.NumPad0,
                NumPad1 = keyboardBusiness.NumPad1,
                NumPad2 = keyboardBusiness.NumPad2,
                NumPad3 = keyboardBusiness.NumPad3,
                NumPad4 = keyboardBusiness.NumPad4,
                NumPad5 = keyboardBusiness.NumPad5,
                NumPad6 = keyboardBusiness.NumPad6,
                NumPad7 = keyboardBusiness.NumPad7,
                NumPad8 = keyboardBusiness.NumPad8,
                NumPad9 = keyboardBusiness.NumPad9,

                Escape = keyboardBusiness.Escape,
                F1 = keyboardBusiness.F1,
                F2 = keyboardBusiness.F2,
                F3 = keyboardBusiness.F3,
                F4 = keyboardBusiness.F4,
                F5 = keyboardBusiness.F5,
                F6 = keyboardBusiness.F6,
                F7 = keyboardBusiness.F7,
                F8 = keyboardBusiness.F8,
                F9 = keyboardBusiness.F9,
                F10 = keyboardBusiness.F10,
                F11 = keyboardBusiness.F11,
                F12 = keyboardBusiness.F12,

                Oemtilde = keyboardBusiness.Oemtilde,
                D1 = keyboardBusiness.D1,
                D2 = keyboardBusiness.D2,
                D3 = keyboardBusiness.D3,
                D4 = keyboardBusiness.D4,
                D5 = keyboardBusiness.D5,
                D6 = keyboardBusiness.D6,
                D7 = keyboardBusiness.D7,
                D8 = keyboardBusiness.D8,
                D9 = keyboardBusiness.D9,
                D0 = keyboardBusiness.D0,
                OemMinus = keyboardBusiness.OemMinus,
                Oemplus = keyboardBusiness.Oemplus,
                Oem5 = keyboardBusiness.Oem5,
                Back = keyboardBusiness.Back,

                Tab = keyboardBusiness.Tab,
                OemOpenBrackets = keyboardBusiness.OemOpenBrackets,
                Oem6 = keyboardBusiness.Oem6,

                Capital = keyboardBusiness.Capital,
                Oem1 = keyboardBusiness.Oem1,
                Oem7 = keyboardBusiness.Oem7,
                Enter = keyboardBusiness.Enter,

                LShiftKey = keyboardBusiness.LShiftKey,
                Oemcomma = keyboardBusiness.Oemcomma,
                OemPeriod = keyboardBusiness.OemPeriod,
                OemQuestion = keyboardBusiness.OemQuestion,
                RShiftKey = keyboardBusiness.RShiftKey,

                LControlKey = keyboardBusiness.LControlKey,
                LWin = keyboardBusiness.LWin,
                Space = keyboardBusiness.Space,
                RWin = keyboardBusiness.RWin,
                Apps = keyboardBusiness.Apps,
                RControlKey = keyboardBusiness.RControlKey,

                PrintScreen = keyboardBusiness.PrintScreen,
                Scroll = keyboardBusiness.Scroll,
                Pause = keyboardBusiness.Pause,

                Insert = keyboardBusiness.Insert,
                Home = keyboardBusiness.Home,
                PageUp = keyboardBusiness.PageUp,
                Delete = keyboardBusiness.Delete,
                End = keyboardBusiness.End,
                Next = keyboardBusiness.Next,

                Left = keyboardBusiness.Left,
                Up = keyboardBusiness.Up,
                Right = keyboardBusiness.Right,
                Down = keyboardBusiness.Down,

                Decimal = keyboardBusiness.Decimal,
                Add = keyboardBusiness.Add,
                Subtract = keyboardBusiness.Subtract,
                Multiply = keyboardBusiness.Multiply,
                Divide = keyboardBusiness.Divide,
                NumLock = keyboardBusiness.NumLock
            };
        }

        public KeyboardBusinessObject ConvertToBusinessObject(EO.Keyboard keyboard)
        {
            return new KeyboardBusinessObject
            {
                TotalKeyHits = keyboard.TotalKeyHits,
                A = keyboard.A,
                B = keyboard.B,
                C = keyboard.C,
                D = keyboard.D,
                E = keyboard.E,
                F = keyboard.F,
                G = keyboard.G,
                H = keyboard.H,
                I = keyboard.I,
                J = keyboard.J,
                K = keyboard.K,
                L = keyboard.L,
                M = keyboard.M,
                N = keyboard.N,
                O = keyboard.O,
                P = keyboard.P,
                Q = keyboard.Q,
                R = keyboard.R,
                S = keyboard.S,
                T = keyboard.T,
                U = keyboard.U,
                V = keyboard.V,
                W = keyboard.W,
                X = keyboard.X,
                Y = keyboard.Y,
                Z = keyboard.Z,

                NumPad0 = keyboard.NumPad0,
                NumPad1 = keyboard.NumPad1,
                NumPad2 = keyboard.NumPad2,
                NumPad3 = keyboard.NumPad3,
                NumPad4 = keyboard.NumPad4,
                NumPad5 = keyboard.NumPad5,
                NumPad6 = keyboard.NumPad6,
                NumPad7 = keyboard.NumPad7,
                NumPad8 = keyboard.NumPad8,
                NumPad9 = keyboard.NumPad9,

                Escape = keyboard.Escape,
                F1 = keyboard.F1,
                F2 = keyboard.F2,
                F3 = keyboard.F3,
                F4 = keyboard.F4,
                F5 = keyboard.F5,
                F6 = keyboard.F6,
                F7 = keyboard.F7,
                F8 = keyboard.F8,
                F9 = keyboard.F9,
                F10 = keyboard.F10,
                F11 = keyboard.F11,
                F12 = keyboard.F12,

                Oemtilde = keyboard.Oemtilde,
                D1 = keyboard.D1,
                D2 = keyboard.D2,
                D3 = keyboard.D3,
                D4 = keyboard.D4,
                D5 = keyboard.D5,
                D6 = keyboard.D6,
                D7 = keyboard.D7,
                D8 = keyboard.D8,
                D9 = keyboard.D9,
                D0 = keyboard.D0,
                OemMinus = keyboard.OemMinus,
                Oemplus = keyboard.Oemplus,
                Oem5 = keyboard.Oem5,
                Back = keyboard.Back,

                Tab = keyboard.Tab,
                OemOpenBrackets = keyboard.OemOpenBrackets,
                Oem6 = keyboard.Oem6,

                Capital = keyboard.Capital,
                Oem1 = keyboard.Oem1,
                Oem7 = keyboard.Oem7,
                Enter = keyboard.Enter,

                LShiftKey = keyboard.LShiftKey,
                Oemcomma = keyboard.Oemcomma,
                OemPeriod = keyboard.OemPeriod,
                OemQuestion = keyboard.OemQuestion,
                RShiftKey = keyboard.RShiftKey,

                LControlKey = keyboard.LControlKey,
                LWin = keyboard.LWin,
                Space = keyboard.Space,
                RWin = keyboard.RWin,
                Apps = keyboard.Apps,
                RControlKey = keyboard.RControlKey,

                PrintScreen = keyboard.PrintScreen,
                Scroll = keyboard.Scroll,
                Pause = keyboard.Pause,

                Insert = keyboard.Insert,
                Home = keyboard.Home,
                PageUp = keyboard.PageUp,
                Delete = keyboard.Delete,
                End = keyboard.End,
                Next = keyboard.Next,

                Left = keyboard.Left,
                Up = keyboard.Up,
                Right = keyboard.Right,
                Down = keyboard.Down,

                Decimal = keyboard.Decimal,
                Add = keyboard.Add,
                Subtract = keyboard.Subtract,
                Multiply = keyboard.Multiply,
                Divide = keyboard.Divide,
                NumLock = keyboard.NumLock
            };
        }
    }
}
