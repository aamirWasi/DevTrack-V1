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
        private readonly IActiveProgramService _activeProgramService;

        public TrackerService(ISnapShotService snapShotService, IWebCamCaptureService webCamCaptureService, IRunningProgramService runningProgramService, IActiveProgramService activeProgramService)
        {
            _snapShotService = snapShotService;
            _webCamCaptureService = webCamCaptureService;
            _runningProgramService = runningProgramService;
            _activeProgramService = activeProgramService;
        }

        public void Track()
        {
            _activeProgramService.SaveActiveProgram();
            _snapShotService.SnapshotCapturer();
            _webCamCaptureService.WebCamCaptureImageSave();
            _runningProgramService.AddCurrentlyRunningPrograms();
        }
    }
}
