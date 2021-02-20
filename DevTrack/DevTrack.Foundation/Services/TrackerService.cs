namespace DevTrack.Foundation.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ISnapShotService _snapShotService;
        private readonly IWebCamCaptureService _webCamCaptureService;
        private readonly IRunningProgramService _runningProgramService;
        private readonly IActiveProgramService _activeProgramService;
        private readonly IKeyboardTrackService _keyboardTrackService;
        private readonly IMouseTrackService _mouseTrackService;

        public TrackerService(
            ISnapShotService snapShotService,
            IWebCamCaptureService webCamCaptureService,
            IRunningProgramService runningProgramService,
            IActiveProgramService activeProgramService,
            IKeyboardTrackService keyboardTrackService,
            IMouseTrackService mouseTrackService)
        {
            _snapShotService = snapShotService;
            _webCamCaptureService = webCamCaptureService;
            _runningProgramService = runningProgramService;
            _activeProgramService = activeProgramService;
            _keyboardTrackService = keyboardTrackService;
            _mouseTrackService = mouseTrackService;
        }

        public void Track()
        {
            _keyboardTrackService.KeyboardTrackSave();
            _mouseTrackService.MouseTrackSave();

            _keyboardTrackService.SyncKeyboardData();
            _mouseTrackService.SyncMouseData();
        }
    }
}
