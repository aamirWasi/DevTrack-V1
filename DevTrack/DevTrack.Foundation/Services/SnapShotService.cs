using DevTrack.Foundation.UnitOfWorks;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DevTrack.Foundation.Services.Adapters;

namespace DevTrack.Foundation.Services
{
    public class SnapShotService : ISnapShotService
    {

        private ISnapshotUnitOfWork _snapshotUnitOfWork;
        private IBitMapAdapter _image;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork,IBitMapAdapter image)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _image = image;
        }
     
        public void SnapshotCapturer()
        {
            var snapshot = _image.GenerateSnapshot();
            var image = snapshot.image;
            if (image == null)
                throw new InvalidOperationException("Image information is missing");

            var imageEntity = new EO.SnapshotImage
            {
                CaptureTime = DateTimeOffset.Now,
                FilePath = snapshot.fileLoaction
            };

            _snapshotUnitOfWork.SnapshotRepository.Add(imageEntity);
            _snapshotUnitOfWork.Save();
        }

        public void SyncSnapShotImages()
        {
            var images = _snapshotUnitOfWork.SnapshotRepository.GetAll();
            if (images.Count > 0 && images!=null)
            {
                foreach (var image in images)
                {
                    var imageEntity = new EO.SnapshotImage
                    {
                        CaptureTime = image.CaptureTime,
                        FilePath = image.FilePath
                    };
                    //SaveSnapshotInSql(imageEntity);
                }
            }
        }

        //private async void SaveSnapshotInSql(EO.SnapshotImage imageEntity)
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:44305/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.PostAsJsonAsync("api/SnapShot", imageEntity);
        //}
    }
}