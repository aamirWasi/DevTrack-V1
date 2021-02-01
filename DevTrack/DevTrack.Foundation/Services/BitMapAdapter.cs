using System;
using System.Drawing;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class BitMapAdapter : IBitMapAdapter
    {
        public int Width { get; set; }
        public IServerTime ServerTime { get; set; }
        public string FilePath { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }

        public BitMapAdapter()
        {
            ServerTime = new ServerTime();
        }

        public (IAdapter image, string fileLoaction) GenerateSnapshot()
        {
            IAdapter _image;
            float dpiX, dpiY;

            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX * 20;
                dpiY = graphics.DpiY * 11.25f;
            }

            Width = (int)Math.Round(dpiX);
            Height = (int)Math.Round(dpiY);
            string newPath = GetDirectoryPath();
            bool exists = Directory.Exists(newPath);
            string imgName = ServerTime.GetTime();
            if (!exists)
            {
                Directory.CreateDirectory(newPath);
            }
            FilePath = newPath +
                      @"\Snapshot" + "_" + imgName
                      + ".jpeg";
            _image = new Adapter(Width, Height);
            var s = new Size(Width, Height);
            var imageGraphics = Graphics.FromImage(_image.Image);
            imageGraphics.CopyFromScreen(0, 0, 0, 0, s);

            _image.SaveImage(FilePath);
            return (_image, FilePath);
        }

        private static string GetDirectoryPath()
        {
            var path = Environment.CurrentDirectory;
            const string imageDirectory = "ScreenShotReceiver";
            return Path.Combine(path, imageDirectory);
        }
    }
}