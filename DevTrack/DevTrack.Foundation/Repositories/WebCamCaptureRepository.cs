﻿using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class WebCamCaptureRepository : Repository<WebCamCaptureEntity, int, DevTrackContext>, IWebCamCaptureRepository
    {
        public WebCamCaptureRepository(DevTrackContext devTrackContext) : base(devTrackContext)
        {

        }
    }
}
