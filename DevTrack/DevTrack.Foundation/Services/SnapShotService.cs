using DevTrack.Foundation.UnitOfWorks;
using BO = DevTrack.Foundation.BusinessObjects;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapShotService : ISnapShotService
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string FilePath { get; set; }
        public string AlternativeText { get; set; }

        private readonly ISnapshotUnitOfWork _snapshotUnitOfWork;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
        }

        public void SnapshotCapturer()
        {
            var snapshot = GenerateSnapshot();
            var image = snapshot.image;
            if (image == null)
                throw new InvalidOperationException("Image information is missing");

            var imageEntity = new EO.SnapshotImage
            {
                FilePath = snapshot.fileLoaction
            };

            _snapshotUnitOfWork.SnapshotRepository.Add(imageEntity);
        }

        private (Image image, string fileLoaction) GenerateSnapshot()
        {
            Bitmap _image;
            float dpiX, dpiY;

            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX * 20;
                dpiY = graphics.DpiY * 11.25f;
            }

            Width = (int)Math.Round(dpiX);
            Height = (int)Math.Round(dpiY);

            _image = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            var s = new Size(_image.Width, _image.Height);

            var imageGraphics = Graphics.FromImage(_image);
            imageGraphics.CopyFromScreen(0, 0, 0, 0, s);
            string newPath = GetDirectoryPath();
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
            return (_image, FilePath);
        }

        private static string GetDirectoryPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var imageDirectory = "ScreenShotReceiver";
            return Path.Combine(path, imageDirectory);
        }
    }
}