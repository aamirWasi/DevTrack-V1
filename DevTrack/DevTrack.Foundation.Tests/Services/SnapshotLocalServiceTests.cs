using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
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
    public class SnapshotLocalServiceTests
    {
        #region Initial_fields
        private const string filePath = @"D:/test";
        SnapshotImage actualImage = new SnapshotImage { Id = 1, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        SnapshotImage expectedImage = new SnapshotImage { Id = 2, CaptureTime = DateTimeOffset.Now, FilePath = filePath };
        #endregion

        #region MockObjects
        private AutoMock _mock;
        private Mock<ISnapshotUnitOfWork> _snapshotUnitOfWorkMock;
        private Mock<IFileManager> _fileManagerMock;
        private Mock<ISnapshotRepository> _snapshotRepositoryMock;
        private ISnapshotLocalService _snapshotLocalService;
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
            _fileManagerMock = _mock.Mock<IFileManager>();
            _snapshotLocalService = _mock.Create<SnapshotLocalService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotUnitOfWorkMock?.Reset();
            _snapshotRepositoryMock?.Reset();
            _fileManagerMock?.Reset();
        }

        [Test]
        public void RemoveImageFromSqLite_ResponseIsFalse_NoImageRemoveFromSqlite()
        {
            //arrange
            var result = "false";

            //act
            _snapshotLocalService.RemoveImageFromSqLite(result, actualImage.Id);

            //assert
            result.ShouldNotBe("true");
            result.ShouldBe("false");
        }

        [Test]
        public void RemoveImageFromSqLite_ResponseIsTrue_RemoveImageFromSqlite()
        {
            //arrange
            var result = "true";
            
            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.GetById(actualImage.Id)).Returns(actualImage);
            _snapshotRepositoryMock.Setup(x => x.Remove(actualImage)).Verifiable();
            _snapshotUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _snapshotLocalService.RemoveImageFromSqLite(result, actualImage.Id);
            actualImage.ShouldNotBe(expectedImage);
            result.ShouldNotBe("false");
            result.ShouldBe("true");

            //assert
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                );
        }

        [Test]
        public void RemoveImageFromFolder_FilePathProvided_RemoveImageFromDirectory()
        {
            //arrange
            _fileManagerMock.Setup(x => x.RemoveFileFromDirectory(filePath)).Verifiable();

            //act
            _snapshotLocalService.RemoveImageFromFolder(filePath);

            //assert
            this.ShouldSatisfyAllConditions(
                () => _fileManagerMock.VerifyAll()
                );
        }
    }
}
