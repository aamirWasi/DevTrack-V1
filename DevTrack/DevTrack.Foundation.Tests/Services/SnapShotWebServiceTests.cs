using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;

namespace DevTrack.Foundation.Tests.Services
{
    public class SnapShotWebServiceTests
    {
        #region MockObjects
        private AutoMock _mock;
        private Mock<ISnapshotWebUnitOfWork> _snapshotWebUnitOfWorkMock;
        private Mock<ISnapshotWebRepository> _snapshotWebRepositoryMock;
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
            _snapshotWebService = _mock.Create<SnapShotWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotWebUnitOfWorkMock?.Reset();
            _snapshotWebRepositoryMock?.Reset();
        }

        [Test]
        public void SnapshotCapturer_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            SnapshotImage imageEntity = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _snapshotWebService.SaveSnapShotWebDb(imageEntity)
                );

            //assert
            imageEntity.ShouldBeNull();
        }

        [Test]
        public void SnapshotCapturer_ImageProvided_SaveImageInSql()
        {
            //arrange
            const string filePath = @"D:/test";
            var actualImage = new SnapshotImage { CaptureTime = DateTimeOffset.Now, FilePath = filePath };
            var expectedImage = new SnapshotImage { CaptureTime = DateTimeOffset.Now, FilePath = filePath };

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
    }
}
