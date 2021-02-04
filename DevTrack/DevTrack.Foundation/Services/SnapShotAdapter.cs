using System.Drawing;

namespace DevTrack.Foundation.Services
{
    public class SnapShotAdapter : ISnapShotAdapter
    {
        public int Width { get; set; }
        public string FilePath { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }

        private Image _bitMap;

        public SnapShotAdapter(int width, int height)
        {
            _bitMap = new Bitmap(width, height);
            Image = _bitMap;
        }

        public void SaveImage(string filePath)
        {
            _bitMap.Save(filePath);
        }
    }
}