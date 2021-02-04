namespace DevTrack.Foundation.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ISnapShotService _snapShotService;
        private readonly IWebCamCaptureService _webCamCaptureService;
        private readonly IRunningProgramService _runningProgramService;
        private readonly IActiveWindowsService _activeWindowsService;
        private readonly IMouseTrackService _mouseTrackService;
        private readonly IKeyboardTrackService _keyboardTrack;

        public TrackerService(
            ISnapShotService snapShotService,
            IWebCamCaptureService webCamCaptureService,
            IRunningProgramService runningProgramService,
            IActiveWindowsService activeWindowsService,
            IKeyboardTrackService keyboardTrackService,
            IMouseTrackService mouseTrackService)
        {
            _snapShotService = snapShotService;
            _webCamCaptureService = webCamCaptureService;
            _runningProgramService = runningProgramService;
            _activeWindowsService = activeWindowsService;
            _mouseTrackService = mouseTrackService;
            _keyboardTrack = keyboardTrackService;
        }

        public void Track()
        {
            //_snapShotService.SnapshotCapturer();
            //_keyboardTrack.KeyboardTrack();
            _mouseTrackService.MouseTrack();
        }
    }
}
