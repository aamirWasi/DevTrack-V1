﻿namespace DevTrack.Foundation.Services
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
            //_snapShotService.SnapshotCapturer();
            //_activeProgramService.SaveActiveProgramLocalDb();
            //_keyboardTrackService.KeyboardTrackSaveToLocal();
            //_mouseTrackService.MouseTrackSaveToLocal();
            //_webCamCaptureService.WebCamCaptureImageSave();
            //_runningProgramService.AddRunningProgramsLocalDb();
        }

        public void Sync()
        {
            //_keyboardTrackService.SyncKeyboardDataFromLocal();
            //_mouseTrackService.SyncMouseDataFromLocal();
            //_snapShotService.SyncSnapShotImages();
            //_activeProgramService.SyncActivePrograms();
            _runningProgramService.SyncRunningPrograms();
            //_webCamCaptureService.SyncWebCamImages();
        }
    }
}
