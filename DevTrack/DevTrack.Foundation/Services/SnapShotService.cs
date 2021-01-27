using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapShotService : ISnapShotService
    {
        public void SnapshotCapturer()
        {
            Bitmap _images;
            float dpiX, dpiY;

            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX * 20;
                dpiY = graphics.DpiY * 20;
            }

            var width = (int)Math.Round(dpiX);
            var height = (int)Math.Round(dpiY);
            _images = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Size s = new Size(_images.Width, _images.Height);
            Graphics imageGraphics = Graphics.FromImage(_images);
            imageGraphics.CopyFromScreen(0, 0, 0, 0, s);
            var imgName = DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)");
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                      @"\Snapshot" + "_" + imgName
                      + ".jpeg");
            _images.Save(fileName);
        }
    }
}