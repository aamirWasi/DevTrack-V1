using System.Drawing;

namespace DevTrack.Foundation.Adapters
{
    public interface IWebCamImageAdapter
    {
        (Image image, string path) WebCamCapture();
    }
}