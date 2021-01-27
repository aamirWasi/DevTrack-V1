namespace DevTrack.Foundation.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly IKeyboardMouseController _keyboardMouse;

        public TrackerService(IKeyboardMouseController keyboardMouse)
        {
            _keyboardMouse = keyboardMouse;
        }
        public void Track()
        {
            _keyboardMouse.TrackKeyboardMouse();
        }
    }
}