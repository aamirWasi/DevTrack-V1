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
        private AutoMock _mock;
        private Mock<ISnapshotUnitOfWork> _snapshotUnitOfWorkMock;
        private Mock<ISnapshotRepository> _snapshotRepositoryMock;
        private Mock<IBitMapAdapter> _bitMapAdapterMock;
        private Mock<ISnapShotAdapter> _adpaterMock;
        private SnapShotService _snapshotService;

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
            _snapshotService = _mock.Create<SnapShotService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotUnitOfWorkMock?.Reset();
            _snapshotRepositoryMock?.Reset();
            _bitMapAdapterMock?.Reset();
            _adpaterMock?.Reset();
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
                ,() => _adpaterMock.VerifyAll()
                );
        }

        [Test]
        public void SnapshotCapturer_ImageProvided_SaveImage()
        {
            //arrange
            ISnapShotAdapter image = new SnapShotAdapter(1000, 1000);
            const string filePath = @"D:/test";
            var imageEntity = new SnapshotImage() { CaptureTime = DateTimeOffset.Now, FilePath = filePath };
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
                ,() => _adpaterMock.VerifyAll()
                , () => _snapshotUnitOfWorkMock.VerifyAll()
                , () => _snapshotRepositoryMock.VerifyAll()
                );
        }
    }
}
