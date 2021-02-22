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
using Microsoft.AspNetCore.Http;
using DevTrack.Foundation.BusinessObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Globalization;

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
            if (images.Count > 0)
            {
                foreach (var image in images)
                {
                    var imageEntity = new EO.SnapshotImage
                    {
                        CaptureTime = image.CaptureTime,
                        FilePath = image.FilePath
                    };

                    //var s = SaveSnapshotInSql(imageEntity);
                    var returnValue = UploadFile(imageEntity);
                }
            }
        }

        private async Task<string> SaveSnapshotInSql(EO.SnapshotImage imageEntity)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44332/");
            var form = new MultipartFormDataContent();
            var file_bytes = File.ReadAllBytes(imageEntity.FilePath);


            //var dt = DateTime.ParseExact(imageEntity.CaptureTime.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //var s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

            form.Add(new StringContent(imageEntity.CaptureTime.ToString("dd/M/yyyy")), "CaptureTime");
            form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "FilePath");
            HttpResponseMessage response = await httpClient.PostAsync("api/SnapShot", form);

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;
            return sd;
        }

        private bool UploadFile(EO.SnapshotImage imageEntity)
        {
            try
            {
                //Stream fileStream = File.OpenRead(imageEntity.FilePath);
                //var image = Image.FromFile(imageEntity.FilePath);
                var snapShot = new SnapshotImage
                {
                    CapturerTime = imageEntity.CaptureTime,
                    //Image = (IFormFile)image
                };

                // byte[] imageByte = ImageToByteArraybyMemoryStream(image);

                //int contentLength = snapShot.Image.ContentLength;
                //byte[] data = new byte[contentLength];
                //fileUpload.PostedFile.InputStream.Read(data, 0, contentLength);

                // Prepare web request...

                var url = "https://localhost:44332/api/SnapShot";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "multipart/form-data";
                var postData = imageEntity.FilePath;
                byte[] data = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = data.Length;

                //request.ContentLength = data.Length;
                using (Stream postStream = webRequest.GetRequestStream())
                {
                    // Send the data.
                   postStream.Write(data, 0, data.Length);
                    postStream.Flush();
                    using var response = webRequest.GetResponse();
                    using var streamItem = response.GetResponseStream();
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log exception here...
                return false;
            }
        }
    }
}