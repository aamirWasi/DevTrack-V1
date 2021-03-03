using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.BusinessObjects
{
    public class Settings
    {
        public int Id { get; set; }
        public bool AllowTracking { get; set; }
        public bool TakeScreenShot { get; set; }
        public bool WebCamCapture { get; set; }
        public bool TrackKeyboardHits { get; set; }
        public bool TrackMouseHits { get; set; }
        public bool TrackRunningProgram { get; set; }
        public bool TrackActiveProgram { get; set; }
    }
}
