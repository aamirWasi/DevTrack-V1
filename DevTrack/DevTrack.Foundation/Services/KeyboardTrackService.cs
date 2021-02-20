using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using Newtonsoft.Json;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private readonly IKeyboardTrackStartService _keyboardTrackAdapter;
        public KeyboardTrackService(
            IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork,
            IKeyboardTrackStartService keyboardTrackAdapter)
        {
            _keyboardTrackUnitOfWork = keyboardTrackUnitOfWork;
            _keyboardTrackAdapter = keyboardTrackAdapter;
        }
        
        public void KeyboardTrackSave()
        {
            var keyboardEntity = _keyboardTrackAdapter.KeyboardEntity();
            if (keyboardEntity == null) return;
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }

        public void SyncKeyboardData()
        {
            var keyboards = _keyboardTrackUnitOfWork.KeyboardTrackRepository.GetAll();
            foreach (var keyboard in keyboards)
            {
                var data = ConvertWithoutId(keyboard);
                SaveDataToWebDb(data);
                DeleteFromLocalDb(keyboard);
            }
        }

        private void DeleteFromLocalDb(Keyboard keyboard)
        {
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Remove(keyboard);
            _keyboardTrackUnitOfWork.Save();
        }

        private static Keyboard ConvertWithoutId(Keyboard keyboard)
        {
            return new Keyboard()
            {
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
                D0 = keyboard.D0,
                D1 = keyboard.D1,
                D2 = keyboard.D2,
                D3 = keyboard.D3,
                D4 = keyboard.D4,
                D5 = keyboard.D5,
                D6 = keyboard.D6,
                D7 = keyboard.D7,
                D8 = keyboard.D8,
                D9 = keyboard.D9,
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
                OemMinus = keyboard.OemMinus,
                Oemplus = keyboard.Oemplus,
                Oem5 = keyboard.Oem5,
                Back = keyboard.Back,
                OemOpenBrackets = keyboard.OemOpenBrackets,
                Tab = keyboard.Tab,
                Oem1 = keyboard.Oem1,
                Oem6 = keyboard.Oem6,
                Oem7 = keyboard.Oem7,
                Capital = keyboard.Capital,
                Enter = keyboard.Enter,
                LShiftKey = keyboard.LShiftKey,
                Oemcomma = keyboard.Oemcomma,
                LControlKey = keyboard.LControlKey,
                RControlKey = keyboard.RControlKey,
                OemPeriod = keyboard.OemPeriod,
                OemQuestion = keyboard.OemQuestion,
                RShiftKey = keyboard.RShiftKey,
                LWin = keyboard.LWin,
                RWin = keyboard.RWin,
                Apps = keyboard.Apps,
                Space = keyboard.Space,
                PrintScreen = keyboard.PrintScreen,
                Scroll = keyboard.Scroll,
                Pause = keyboard.Pause,
                Insert = keyboard.Insert,
                PageUp = keyboard.PageUp,
                Delete = keyboard.Delete,
                End = keyboard.End,
                Next = keyboard.Next,
                Left = keyboard.Left,
                Right = keyboard.Right,
                Up = keyboard.Up,
                Down = keyboard.Down,
                TotalKeyHits = keyboard.TotalKeyHits,
                Decimal = keyboard.Decimal,
                Add = keyboard.Add,
                Subtract = keyboard.Subtract,
                Multiply = keyboard.Multiply,
                Divide = keyboard.Divide,
            };
        }
        private static void SaveDataToWebDb(Keyboard keyboard)
        {
            const string url = "https://localhost:44332/api/Keyboard";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var requestContent = JsonConvert.SerializeObject(keyboard);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;


            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
