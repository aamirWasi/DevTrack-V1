﻿using DevTrack.Foundation.UnitOfWorks;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
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
        private readonly ISnapshotLocalService _snapshotLocalService;
        private readonly IHelper _helper;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork, IBitMapAdapter image, ISnapshotApiService snapshotApiService, ISnapshotLocalService snapshotLocalService, IHelper helper)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _image = image;
            _snapshotApiService = snapshotApiService;
            _snapshotLocalService = snapshotLocalService;
            _helper = helper;
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
            if (images!=null && images.Count>0)
            {
                foreach (var image in images)
                {
                    var imageEntity = new EO.SnapshotImage
                    {
                        CaptureTime = image.CaptureTime,
                        FilePath = image.FilePath
                    };

                    var result = _snapshotApiService.SaveSnapshotInSql(imageEntity);
                    if (result != "true")
                    {
                        throw new ArgumentException("Result is false");
                    }
                    else
                    {
                        _snapshotLocalService.RemoveImageFromSqLite(result, image.Id);
                        _snapshotLocalService.RemoveImageFromFolder(_helper.GetFilePath(imageEntity.FilePath));
                    }
                }
            }
        }
    }
}