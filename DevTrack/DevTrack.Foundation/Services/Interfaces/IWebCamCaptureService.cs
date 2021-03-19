using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IWebCamCaptureService
    {
        public void WebCamCaptureImageSave();
        public void SyncWebCamImages();
    }
}
