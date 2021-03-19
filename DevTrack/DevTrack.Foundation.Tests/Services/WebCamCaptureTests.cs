 using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using NUnit.Framework;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using DevTrack.Foundation.Adapters;
using Shouldly;
using Moq;
using DevTrack.Foundation.Services;
using System.Drawing;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Tests.Services
{
    class WebCamCaptureTests
    {
        private AutoMock _mock;
        private Mock<IWebCamCaptureUnitOfWork> _webCamCaptureUnitOfWorkMock;
        private Mock<IWebCamCaptureRepository> _webCamCaptureRepositoryMock;
        private Mock<IWebCamImageAdapter> _webCamImageAdapterMock;
        private IWebCamCaptureService _webCamCaptureService;

        [OneTimeSetUp]
        public void ClassTestUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _webCamCaptureRepositoryMock = _mock.Mock<IWebCamCaptureRepository>();
            _webCamCaptureUnitOfWorkMock = _mock.Mock<IWebCamCaptureUnitOfWork>();
            _webCamImageAdapterMock = _mock.Mock<IWebCamImageAdapter>();
            _webCamCaptureService = _mock.Create<WebCamCaptureService>();
        }

        [TearDown]
        public void Clean()
        {
            _webCamCaptureRepositoryMock?.Reset();
            _webCamCaptureUnitOfWorkMock?.Reset();
            _webCamImageAdapterMock?.Reset();
        }

        [Test]
        public void WebCamCaptureImageSave_NoImageFound_ThrowsInvalidOperationException()
        {
            //arrange
            (Image image, string path) obj = (null, null);
            _webCamImageAdapterMock.Setup(x => x.WebCamCapture()).Returns(obj);

            //act
            Should.Throw<InvalidOperationException>(
                () => _webCamCaptureService.WebCamCaptureImageSave()
                );

            //assert
            this.ShouldSatisfyAllConditions(
                () => _webCamImageAdapterMock.VerifyAll()
                );
        }

        [Test]
        public void WebCamCaptureImageSave_ImageFound_ImageSave()
        {
            //arrange
            Image image = new Bitmap(400, 400);
            const string ImagePath = @"C:\camTest";
            var imageEntity = new WebCamCaptureImage() { WebCamImageDateTime = DateTime.Now, WebCamImagePath = ImagePath };
            (Image image, string ImagePath) obj = (image, ImagePath);

            _webCamCaptureUnitOfWorkMock.Setup(x => x.WebCamCaptureRepository).Returns(_webCamCaptureRepositoryMock.Object);
            _webCamImageAdapterMock.Setup(x => x.WebCamCapture()).Returns(obj);
            _webCamCaptureRepositoryMock.Setup(x => x.Add(It.Is<WebCamCaptureImage>(y => y.WebCamImagePath == imageEntity.WebCamImagePath))).Verifiable();
            _webCamCaptureUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _webCamCaptureService.WebCamCaptureImageSave();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _webCamImageAdapterMock.VerifyAll()
                , () => _webCamCaptureUnitOfWorkMock.VerifyAll()
                , () => _webCamCaptureRepositoryMock.VerifyAll()
                );


        }

        [Test]
        public void SyncSnapShotImages_NoImageFound_ReturnNull()
        {
            //arrange
            IList<WebCamCaptureImage> actualImages = null;
            _webCamCaptureUnitOfWorkMock.Setup(x => x.WebCamCaptureRepository).Returns(_webCamCaptureRepositoryMock.Object);
            _webCamCaptureRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();

            //act
            _webCamCaptureService.SyncWebCamImages();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _webCamCaptureUnitOfWorkMock.VerifyAll(),
                () => _webCamCaptureRepositoryMock.VerifyAll()
                );
        }
    }
}
