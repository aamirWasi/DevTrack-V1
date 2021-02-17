using DevTrack.DataAccessLayer;

namespace DevTrack.Foundation.Entities
{
    public class Settings : IEntity<int>
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
