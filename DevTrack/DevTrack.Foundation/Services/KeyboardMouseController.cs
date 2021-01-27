using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DevTrack.Foundation.Services
{
    public class KeyboardMouseController : IKeyboardMouseController
    {
        private readonly IKeyboardTrackService _keyboardTrack;
        private readonly IMouseTrackService _mouseTrack;

        public KeyboardMouseController(IKeyboardTrackService keyboardTrack, IMouseTrackService mouseTrack)
        {
            _keyboardTrack = keyboardTrack;
            _mouseTrack = mouseTrack;
        }

        public void TrackKeyboardMouse()
        {
            _keyboardTrack.KeyboardTrack();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }
    }
}
