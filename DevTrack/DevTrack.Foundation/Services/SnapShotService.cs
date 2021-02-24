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
        private readonly ISnapshotUnitOfWork _snapshotUnitOfWork;
        private readonly IBitMapAdapter _image;
        private readonly ISnapshotApiService _snapshotApiService;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork,IBitMapAdapter image, ISnapshotApiService snapshotApiService)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _image = image;
            _snapshotApiService = snapshotApiService;
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

                    var result = _snapshotApiService.SaveSnapshotInSql(imageEntity);
                }
            }
        }
    }
}