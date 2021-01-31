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

        public TrackerService(ISnapShotService snapShotService, IWebCamCaptureService webCamCaptureService, IRunningProgramService runningProgramService, IActiveWindowsService activeWindowsService)
        {
            _snapShotService = snapShotService;
            _webCamCaptureService = webCamCaptureService;
            _runningProgramService = runningProgramService;
            _activeWindowsService = activeWindowsService;
        }

        public void Track()
        {
            _snapShotService.SnapshotCapturer();
        }
    }
}
