using System.Drawing;

namespace DevTrack.Foundation.Services.Adapters
{
    public interface ISnapShotAdapter
    {
        int Width { get; }
        int Height { get; }
        void SaveImage(string filePath);
        Image Image { get; set; }
    }
}