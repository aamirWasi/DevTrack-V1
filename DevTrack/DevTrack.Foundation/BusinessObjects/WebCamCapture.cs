using Microsoft.AspNetCore.Http;

namespace DevTrack.Foundation.BusinessObjects
{
    public class WebCamCapture
    {
        public string Location { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
