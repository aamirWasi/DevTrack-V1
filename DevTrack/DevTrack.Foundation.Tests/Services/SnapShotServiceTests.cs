using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;
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
    public class SnapShotServiceTests
    {
        #region Initial_fields
        const string filePath = @"D:/test";
        const string result = "true";
        SnapshotImage imageEntity = new SnapshotImage { Id = 1, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        SnapshotImage imageEntity2 = new SnapshotImage { Id = 2, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<ISnapshotUnitOfWork> _snapshotUnitOfWorkMock;
        private Mock<ISnapshotRepository> _snapshotRepositoryMock;
        private Mock<IBitMapAdapter> _bitMapAdapterMock;
        private Mock<ISnapShotAdapter> _adpaterMock;
        private ISnapShotService _snapshotService;
        private Mock<ISnapshotApiService> _snapshotApiServiceMock;
        private Mock<ISnapshotLocalService> _snapshotLocalServiceMock;
        private Mock<IFileManager> _fileManagerMock;
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
            _snapshotRepositoryMock = _mock.Mock<ISnapshotRepository>();
            _snapshotUnitOfWorkMock = _mock.Mock<ISnapshotUnitOfWork>();
            _bitMapAdapterMock = _mock.Mock<IBitMapAdapter>();
            _adpaterMock = _mock.Mock<ISnapShotAdapter>();
            _snapshotApiServiceMock = _mock.Mock<ISnapshotApiService>();
            _snapshotLocalServiceMock = _mock.Mock<ISnapshotLocalService>();
            _fileManagerMock = _mock.Mock<IFileManager>();
            _snapshotService = _mock.Create<SnapShotService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotUnitOfWorkMock?.Reset();
            _snapshotRepositoryMock?.Reset();
            _bitMapAdapterMock?.Reset();
            _adpaterMock?.Reset();
            _snapshotApiServiceMock?.Reset();
            _snapshotLocalServiceMock?.Reset();
            _fileManagerMock?.Reset();
        }

        [Test]
        public void SnapshotCapturer_NoImageProvided_ThrowsInvalidOperationException()
        {
            //arrange
            (ISnapShotAdapter image, string filePath) obj = (null, null);
            _bitMapAdapterMock.Setup(x => x.GenerateSnapshot()).Returns(obj);

            //act
            Should.Throw<InvalidOperationException>(
                () => _snapshotService.SnapshotCapturer()
                );

            //assert
            this.ShouldSatisfyAllConditions(
                () => _bitMapAdapterMock.VerifyAll()
                , () => _adpaterMock.VerifyAll()
                );
        }

        [Test]
        public void SnapshotCapturer_ImageProvided_SaveImage()
        {
            //arrange
            ISnapShotAdapter image = new SnapShotAdapter(1000, 1000);
            (ISnapShotAdapter image, string filePath) obj = (image, filePath);

            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _bitMapAdapterMock.Setup(x => x.GenerateSnapshot()).Returns(obj);
            _snapshotRepositoryMock.Setup(x => x.Add(It.Is<SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Verifiable();
            _snapshotUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _snapshotService.SnapshotCapturer();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _bitMapAdapterMock.VerifyAll()
                , () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void SyncSnapShotImages_NoSnapshotImageIsProvided_ReturnNull()
        {
            //arrange
            IList<SnapshotImage> actualImages = null;
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();

            //act
            _snapshotService.SyncSnapShotImages();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void SyncSnapShotImages_SnapshotImagesProvided_ReturnTrueForEqualCount()
        {
            //arrange
            var actualImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            var expectedImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();
            _snapshotApiServiceMock.Setup(x => x.SaveSnapshotInSql(It.Is<SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Returns(result);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromSqLite(result, imageEntity.Id)).Verifiable();
            _fileManagerMock.Setup(x => x.GetFilePath(filePath)).Returns(imageEntity.FilePath);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromFolder(filePath)).Verifiable();

            //act
            _snapshotService.SyncSnapShotImages();

            //assert
            actualImages.ShouldBe(expectedImages, "Actual & expected images both are equal");
            actualImages.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                , () => _snapshotApiServiceMock.VerifyAll()
                , () => _snapshotLocalServiceMock.VerifyAll()
                );
        }

        [Test]
        public void SyncSnapShotImages_SnapshotsProvided_SyncSuccessfully()
        {
            //arrange
            var actualImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            var expectedImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();
            _snapshotApiServiceMock.Setup(x => x.SaveSnapshotInSql(It.Is<SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Returns(result);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromSqLite(result, imageEntity.Id)).Verifiable();
            _fileManagerMock.Setup(x => x.GetFilePath(filePath)).Returns(imageEntity.FilePath);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromFolder(filePath)).Verifiable();

            //act
            _snapshotService.SyncSnapShotImages();

            //assert
            actualImages.ShouldBe(expectedImages, "Actual & expected images both are equal");
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                , () => _snapshotApiServiceMock.VerifyAll()
                , () => _snapshotLocalServiceMock.VerifyAll()
                );
        }
    }
}
