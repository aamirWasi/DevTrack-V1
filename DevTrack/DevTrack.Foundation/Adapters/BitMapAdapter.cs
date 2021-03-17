using System;
using System.Drawing;
using System.IO;

namespace DevTrack.Foundation.Services.Adapters
{
    public class BitMapAdapter : IBitMapAdapter
    {
        public int Width { get; set; }
        public string FilePath { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }

        private IServerTime _serverTime { get; set; }
        private IFileManager _fileManager { get; set; }

        public BitMapAdapter()
        {
            _serverTime = new ServerTime();
            _fileManager = new FileManager();
        }

        public (ISnapShotAdapter image, string fileLoaction) GenerateSnapshot()
        {
            ISnapShotAdapter _image;
            float dpiX, dpiY;

            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX * 20;
                dpiY = graphics.DpiY * 11.25f;
            }

            Width = (int)Math.Round(dpiX);
            Height = (int)Math.Round(dpiY);
            string newPath = _fileManager.GetFilePath();
            bool exists = Directory.Exists(newPath);
            string imgName = _serverTime.GetTime();

            if (!exists)
            {
                Directory.CreateDirectory(newPath);
            }

            const string folderName = @"\Snapshot" + "_";
            const string extensions = @".jpeg";

            FilePath = $"{newPath}{folderName}{imgName}{extensions}";
            _image = new SnapShotAdapter(Width, Height);

            var s = new Size(Width, Height);

            var imageGraphics = Graphics.FromImage(_image.Image);
            imageGraphics.CopyFromScreen(0, 0, 0, 0, s);

            _image.SaveImage(FilePath);
            return (_image, FilePath);
        }
    }
}