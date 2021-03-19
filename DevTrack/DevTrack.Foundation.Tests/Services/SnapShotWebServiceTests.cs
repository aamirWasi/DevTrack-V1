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
    public class SnapShotWebServiceTests
    {
        #region Initial_Fields
        const string filePath = @"D:/test";
        SnapshotImage actualImage = new SnapshotImage { CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        SnapshotImage expectedImage = new SnapshotImage { CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<ISnapshotWebUnitOfWork> _snapshotWebUnitOfWorkMock;
        private Mock<ISnapshotWebRepository> _snapshotWebRepositoryMock;
        private Mock<ISnapShotWebAdapterService> _snapShotWebAdapterServiceMock;
        private ISnapShotWebService _snapshotWebService;
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
            _snapshotWebRepositoryMock = _mock.Mock<ISnapshotWebRepository>();
            _snapshotWebUnitOfWorkMock = _mock.Mock<ISnapshotWebUnitOfWork>();
            _snapShotWebAdapterServiceMock = _mock.Mock<ISnapShotWebAdapterService>();
            _snapshotWebService = _mock.Create<SnapShotWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotWebUnitOfWorkMock?.Reset();
            _snapshotWebRepositoryMock?.Reset();
            _snapShotWebAdapterServiceMock?.Reset();
        }

        [Test]
        public void SaveSnapShotWebDb_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            SnapshotImage imageEntity = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _snapshotWebService.SaveSnapShotWebDb(imageEntity)
                );

            //assert
            imageEntity.ShouldNotBe(actualImage);
        }

        [Test]
        public void SaveSnapShotWebDb_ImageProvided_SaveImageInSql()
        {
            //arrange
            _snapshotWebUnitOfWorkMock.Setup(x => x.SnapshotWebRepository).Returns(_snapshotWebRepositoryMock.Object);
            _snapshotWebRepositoryMock.Setup(x => x.Add(It.Is<SnapshotImage>(y => y.FilePath == actualImage.FilePath))).Verifiable();
            _snapshotWebUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _snapshotWebService.SaveSnapShotWebDb(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            actualImage.ShouldNotBe(expectedImage);
            this.ShouldSatisfyAllConditions(
                () => _snapshotWebUnitOfWorkMock.VerifyAll()
                , () => _snapshotWebRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void SaveSnapshotInSql_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            SnapshotImage imageEntity = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _snapshotWebService.SaveSnapshotInSql(imageEntity)
                );

            //assert
            imageEntity.ShouldNotBe(actualImage);
        }

        [Test]
        public void SaveSnapshotInSql_ImageProvided_ReturnsResponseTrue()
        {
            //arrange
            var result = "true";
            _snapShotWebAdapterServiceMock.Setup(x => x.WebHttpResponse(It.Is<SnapshotImage>(y => y.FilePath == actualImage.FilePath))).Returns("true");

            //act
            var response = _snapshotWebService.SaveSnapshotInSql(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            result.ShouldBe(response);
            _snapShotWebAdapterServiceMock.VerifyAll();
        }

        [Test]
        public void SaveSnapshotInSql_ImageProvided_ReturnsResponseFalse()
        {
            //arrange
            var result = "true";
            _snapShotWebAdapterServiceMock.Setup(x => x.WebHttpResponse(It.Is<SnapshotImage>(y => y.FilePath == actualImage.FilePath))).Returns("false");

            //act
            var response = _snapshotWebService.SaveSnapshotInSql(actualImage);

            //assert
            actualImage.ShouldNotBeNull();
            result.ShouldNotBe(response);
            _snapShotWebAdapterServiceMock.VerifyAll();
        }
    }
}
