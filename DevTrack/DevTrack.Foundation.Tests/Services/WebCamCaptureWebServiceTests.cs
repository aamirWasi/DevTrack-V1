using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;

namespace DevTrack.Foundation.Tests.Services
{
    class WebCamCaptureWebServiceTests
    {
        #region Initial_Fields
        const string filePath = @"D:/test";
        WebCamCaptureImage actualImage = new WebCamCaptureImage { WebCamImageDateTime = DateTimeOffset.Now, WebCamImagePath = filePath };
        WebCamCaptureImage expectedImage = new WebCamCaptureImage { WebCamImageDateTime = DateTimeOffset.Now, WebCamImagePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<IWebCamCaptureWebUnitOfWork> _webCamCaptureWebUnitOfWorkMock;
        private Mock<IWebCamCaptureWebRepository> _webCamCaptureWebRepositoryMock;
        private Mock<IWebCamCaptureAdapterService> _webCamCaptureAdapterServiceMock;
        private IWebCamCaptureWebService _webCamCaptureWebService;
        #endregion

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
            _webCamCaptureWebRepositoryMock = _mock.Mock<IWebCamCaptureWebRepository>();
            _webCamCaptureWebUnitOfWorkMock = _mock.Mock<IWebCamCaptureWebUnitOfWork>();
            _webCamCaptureAdapterServiceMock = _mock.Mock<IWebCamCaptureAdapterService>();
            _webCamCaptureWebService = _mock.Create<WebCamCaptureWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _webCamCaptureWebUnitOfWorkMock?.Reset();
            _webCamCaptureWebRepositoryMock?.Reset();
            _webCamCaptureAdapterServiceMock?.Reset();
        }

        [Test]
        public void WebCamCapturer_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            WebCamCaptureImage imageEntity = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _webCamCaptureWebService.SaveSnapShotWebDb(imageEntity)
                );

            //assert
            imageEntity.ShouldNotBe(actualImage);
        }

        [Test]
        public void WebCamCapturer_ImageProvided_SaveImageInSql()
        {
            //arrange
            _webCamCaptureWebUnitOfWorkMock.Setup(x => x._webCamCaptureWebRepository).Returns(_webCamCaptureWebRepositoryMock.Object);
            _webCamCaptureWebRepositoryMock.Setup(x => x.Add(It.Is<WebCamCaptureImage>(y => y.WebCamImagePath == actualImage.WebCamImagePath))).Verifiable();
            _webCamCaptureWebUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _webCamCaptureWebService.SaveSnapShotWebDb(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            actualImage.ShouldNotBe(expectedImage);
            this.ShouldSatisfyAllConditions(
                () => _webCamCaptureWebUnitOfWorkMock.VerifyAll()
                , () => _webCamCaptureWebRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void SaveWebCamInSql_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            WebCamCaptureImage imageEntity = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _webCamCaptureWebService.SaveSnapshotInSql(imageEntity)
                );

            //assert
            imageEntity.ShouldNotBe(actualImage);
        }

        [Test]
        public void SaveWebCamInSql_ImageProvided_ReturnsResponseTrue()
        {
            //arrange
            var result = "true";
            _webCamCaptureAdapterServiceMock.Setup(x => x.WebHttpResponse(It.Is<WebCamCaptureImage>(y => y.WebCamImagePath == actualImage.WebCamImagePath))).Returns("true");

            //act
            var response = _webCamCaptureWebService.SaveSnapshotInSql(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            result.ShouldBe(response);
            _webCamCaptureAdapterServiceMock.VerifyAll();
        }

        [Test]
        public void SaveWebCamInSql_ImageProvided_ReturnsResponseFalse()
        {
            //arrange
            var result = "true";
            _webCamCaptureAdapterServiceMock.Setup(x => x.WebHttpResponse(It.Is<WebCamCaptureImage>(y => y.WebCamImagePath == actualImage.WebCamImagePath))).Returns("false");

            //act
            var response = _webCamCaptureWebService.SaveSnapshotInSql(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            result.ShouldNotBe(response);
            _webCamCaptureAdapterServiceMock.VerifyAll();
        }

    }
}
