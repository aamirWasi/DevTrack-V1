using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class WebCamCaptureUnitOfWork : UnitOfWork, IWebCamCaptureUnitOfWork
    {
        public IWebCamCaptureRepository WebCamCaptureRepository { get; set; }

        public WebCamCaptureUnitOfWork(DevTrackContext webCamContext, IWebCamCaptureRepository webCamRepository) : base(webCamContext)
        {
            WebCamCaptureRepository = webCamRepository;
        }
    }
}
