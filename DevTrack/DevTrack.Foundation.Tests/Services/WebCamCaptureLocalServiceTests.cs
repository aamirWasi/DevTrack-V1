using Autofac.Extras.Moq;
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.Tests.Services
{
    class WebCamCaptureLocalServiceTests
    {
        #region Initial_fields
        private const string filePath = @"D:/test";
        WebCamCaptureImage actualImage = new WebCamCaptureImage { Id = 1, WebCamImageDateTime = DateTimeOffset.Now, WebCamImagePath = filePath };
        WebCamCaptureImage expectedImage = new WebCamCaptureImage { Id = 2, WebCamImageDateTime = DateTimeOffset.Now, WebCamImagePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<IWebCamCaptureUnitOfWork> _webCamCaptureUnitOfWorkMock;
        private Mock<IWebCamCaptureRepository> _webCamCaptureRepositoryMock;
        private Mock<IFileManager> _fileManagerMock;
        private IWebCamCaptureLocalService _webCamCaptureLocalService;
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
            _webCamCaptureRepositoryMock = _mock.Mock<IWebCamCaptureRepository>();
            _webCamCaptureUnitOfWorkMock = _mock.Mock<IWebCamCaptureUnitOfWork>();
            _fileManagerMock = _mock.Mock<IFileManager>();
            _webCamCaptureLocalService = _mock.Create<WebCamCaptureLocalService>();
        }

        [TearDown]
        public void Clean()
        {
            _webCamCaptureUnitOfWorkMock?.Reset();
            _webCamCaptureRepositoryMock?.Reset();
            _fileManagerMock?.Reset();
        }

        [Test]
        public void RemoveImageFromSqLite_ResponseIsFalse_ThrowsInvalidProgramException()
        {
            //arrange
            var result = "false";

            //act
            Should.Throw<InvalidProgramException>(
                () => _webCamCaptureLocalService.RemoveImageFromSqLite(result, actualImage.Id)
            );

            //assert
            result.ShouldNotBe("true");
            _fileManagerMock.VerifyAll();
        }

        [Test]
        public void RemoveImageFromSqLite_ResponseIsTrue_RemoveImageFromSqlite()
        {
            //arrange
            var result = "true";

            _webCamCaptureUnitOfWorkMock.Setup(x => x.WebCamCaptureRepository).Returns(_webCamCaptureRepositoryMock.Object);
            _webCamCaptureRepositoryMock.Setup(x => x.GetById(actualImage.Id)).Returns(actualImage);
            _webCamCaptureRepositoryMock.Setup(x => x.Remove(actualImage)).Verifiable();
            _webCamCaptureUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _webCamCaptureLocalService.RemoveImageFromSqLite(result, actualImage.Id);

            //assert
            actualImage.ShouldNotBe(expectedImage);
            result.ShouldNotBe("false");
            this.ShouldSatisfyAllConditions(
                () => _webCamCaptureUnitOfWorkMock.VerifyAll(),
                () => _webCamCaptureRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void RemoveImageFromFolder_ImagePathProvided_RemoveImageFromDirectory()
        {
            //arrange
            _fileManagerMock.Setup(x => x.RemoveFileFromDirectory(filePath)).Verifiable();

            //act
            _webCamCaptureLocalService.RemoveImageFromFolder(filePath);
            //_snapshotLocalService.RemoveImageFromFolder(filePath);

            //assert
            _fileManagerMock.VerifyAll();
        }

        [Test]
        public void RemoveImageFromFolder_ImagePathNotProvided_ThrowsInvalidOperationException()
        {
            //arrange
            const string filePathEmpty = null;

            //act
            Should.Throw<InvalidOperationException>(
                    () => _webCamCaptureLocalService.RemoveImageFromFolder(filePathEmpty)
                    );

            //assert
            filePathEmpty.ShouldNotBe(filePath);
        }
    }
}
