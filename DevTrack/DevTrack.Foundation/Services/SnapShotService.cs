using DevTrack.Foundation.UnitOfWorks;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DevTrack.Foundation.Services.Adapters;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Text;

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
                    SaveSnapshotInSql(imageEntity);
                }
            }
        }

        private void SaveSnapshotInSql(EO.SnapshotImage imageEntity)
        {
            const string url = "https://localhost:44332/api/SnapShot";
            var request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            //request.ContentType = "multipart/form-data";            
            var requestContent = JsonConvert.SerializeObject(imageEntity);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            var result = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        //private async void SaveSnapshotInSql(EO.SnapshotImage imageEntity)
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:44332/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.PostAsJsonAsync("api/Snapshot", imageEntity);
        //}
    }
}