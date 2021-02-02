using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ISnapShotService _snapShotService;
        private readonly IWebCamCaptureService _webCamCaptureService;
        private readonly IRunningProgramService _runningProgramService;
        private readonly IActiveWindowsService _activeWindowsService;
        private readonly IKeyboardTrackService _keyboardTrack;

        public TrackerService(ISnapShotService snapShotService, IWebCamCaptureService webCamCaptureService, IRunningProgramService runningProgramService, IActiveWindowsService activeWindowsService, IKeyboardTrackService keyboardTrack)
        {
            _snapShotService = snapShotService;
            _webCamCaptureService = webCamCaptureService;
            _runningProgramService = runningProgramService;
            _activeWindowsService = activeWindowsService;
            _keyboardTrack = keyboardTrack;
        }

        public void Track()
        {
            //_snapShotService.SnapshotCapturer();
            _keyboardTrack.KeyboardTrack();
        }
    }
}
