using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.BusinessObjects
{
    public class SnapshotImage
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string FilePath { get; set; }
        public string AlternativeText { get; set; }

        public void GenerateSnapshot()
        {
            Bitmap _image;
            float dpiX, dpiY;

            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX * 20;
                dpiY = graphics.DpiY * 20;
            }

            Width = (int)Math.Round(dpiX);
            Height = (int)Math.Round(dpiY);

            _image = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            var s = new Size(_image.Width, _image.Height);

            var imageGraphics = Graphics.FromImage(_image);
            imageGraphics.CopyFromScreen(0, 0, 0, 0, s);
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var imageDirectory = "ScreenShotReceiver";
            var newPath = Path.Combine(path, imageDirectory);
            bool exists = Directory.Exists(newPath);
            string imgName = DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)");
            if (!exists)
            {
                Directory.CreateDirectory(newPath);
            }
            FilePath = newPath +
                      @"\Snapshot" + "_" + imgName
                      + ".jpeg";
            _image.Save(FilePath);
        }
    }
}
