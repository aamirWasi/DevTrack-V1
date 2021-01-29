using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ISnapShotService _snapShotService;

        public TrackerService(ISnapShotService snapShotService)
        {
            _snapShotService = snapShotService;
        }

        public void Track()
        {
            throw new NotImplementedException();
        }
    }
}
