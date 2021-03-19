using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Adapters;
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
    public class SnapShotServiceTests
    {
        #region Initial_fields
        const string filePath = @"D:/test";
        const string result = "true";
        SnapshotImage imageEntity = new SnapshotImage { Id = 1, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        SnapshotImage imageEntity2 = new SnapshotImage { Id = 2, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        SnapshotImage imageEntity3 = new SnapshotImage { Id = 21, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<ISnapshotUnitOfWork> _snapshotUnitOfWorkMock;
        private Mock<ISnapshotRepository> _snapshotRepositoryMock;
        private Mock<IBitMapAdapter> _bitMapAdapterMock;
        private ISnapShotService _snapshotService;
        private Mock<ISnapShotWebService> _snapshotWebServiceMock;
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
            _snapshotWebServiceMock = _mock.Mock<ISnapShotWebService>();
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
            _snapshotWebServiceMock?.Reset();
            _snapshotLocalServiceMock?.Reset();
            _fileManagerMock?.Reset();
        }

        [Test]
        public void SnapshotCapturer_NoImageFound_ThrowsInvalidOperationException()
        {
            //arrange
            (ISnapShotAdapter image, string filePath) imageInfo = (null, null);
            _bitMapAdapterMock.Setup(x => x.GenerateSnapshot()).Returns(imageInfo);

            //act
            Should.Throw<InvalidOperationException>(
                () => _snapshotService.SnapshotCapturer()
                );

            //assert
            _bitMapAdapterMock.VerifyAll();
        }

        [Test]
        public void SnapshotCapturer_ImageFound_SaveImageInLocalStorage()
        {
            //arrange
            ISnapShotAdapter image = new SnapShotAdapter(1000, 1000);
            (ISnapShotAdapter image, string filePath) imageInfo = (image, filePath);

            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _bitMapAdapterMock.Setup(x => x.GenerateSnapshot()).Returns(imageInfo);
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
        public void SyncSnapShotImages_NoImageFound_ReturnNull()
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
        public void SyncSnapShotImages_ImagesFound_ReturnTrueForEqualCount()
        {
            //arrange
            var actualImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            var expectedImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();
            _snapshotWebServiceMock.Setup(x => x.SaveSnapshotInSql(It.Is<SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Returns(result);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromSqLite(result, imageEntity.Id)).Verifiable();
            _fileManagerMock.Setup(x => x.GetFilePath(filePath)).Returns(imageEntity.FilePath);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromFolder(filePath)).Verifiable();

            //act
            _snapshotService.SyncSnapShotImages();

            //assert
            actualImages.ShouldBe(expectedImages, "Actual & expected images both are equal in count & same instances");
            actualImages.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                , () => _snapshotWebServiceMock.VerifyAll()
                , () => _snapshotLocalServiceMock.VerifyAll()
                );
        }

        [Test]
        public void SyncSnapShotImages_ImagesFileNotFound_ThrowsArgumentException()
        {
            //arrange
            const string imageFilePath = null;
            const string returnResponse = "false";
            var snapshotImage = new SnapshotImage { Id = 1, CaptureTime = DateTimeOffset.Now, FilePath = imageFilePath };
            var actualImages = new List<SnapshotImage> { snapshotImage };
            var expectedImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();
            _snapshotWebServiceMock.Setup(x => x.SaveSnapshotInSql(It.Is<SnapshotImage>(y => y.FilePath == snapshotImage.FilePath))).Returns(returnResponse);

            //act
            Should.Throw<ArgumentException>(
            () => _snapshotService.SyncSnapShotImages()
            );

            //assert
            actualImages.ShouldNotBe(expectedImages, "Actual & expected images both are equal in count & same instances");
            actualImages.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                , () => _snapshotWebServiceMock.VerifyAll()
                );
        }

        [Test]
        public void SyncSnapShotImages_SnapshotsFound_SyncSuccessfully()
        {
            //arrange
            var actualImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            var expectedImages = new List<SnapshotImage> { imageEntity, imageEntity2 };
            var expectedSnapshots = new List<SnapshotImage> { imageEntity, imageEntity2,imageEntity3 };
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetAll()).Returns(actualImages).Verifiable();
            _snapshotWebServiceMock.Setup(x => x.SaveSnapshotInSql(It.Is<SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Returns(result);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromSqLite(result, imageEntity.Id)).Verifiable();
            _fileManagerMock.Setup(x => x.GetFilePath(filePath)).Returns(imageEntity.FilePath);
            _snapshotLocalServiceMock.Setup(x => x.RemoveImageFromFolder(filePath)).Verifiable();

            //act
            _snapshotService.SyncSnapShotImages();

            //assert
            actualImages.ShouldBe(expectedImages, "Actual & expected images both are equal");
            actualImages.ShouldNotBe(expectedSnapshots);
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                , () => _snapshotWebServiceMock.VerifyAll()
                , () => _snapshotLocalServiceMock.VerifyAll()
                );
        }
    }
}
