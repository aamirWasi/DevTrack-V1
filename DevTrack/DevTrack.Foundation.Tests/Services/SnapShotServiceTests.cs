using Autofac.Extras.Moq;
using DevTrack.Foundation.BusinessObjects;
using EO=DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    public class SnapShotServiceTests
    {
        private AutoMock _mock;
        private Mock<ISnapshotUnitOfWork> _snapshotUnitOfWorkMock;
        private Mock<ISnapshotRepository> _snapshotRepositoryMock;
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
            _snapshotService = _mock.Create<SnapShotService>();
        }

        [TearDown]
        public void Clean()
        {
            _snapshotUnitOfWorkMock?.Reset();
            _snapshotRepositoryMock?.Reset();
        }

        [Test]
        public void SnapshotCapturer_ImageProvided_SaveImage()
        {
            //arrange
            const int id = 1;
            const string imageUrl = "Snapshot_(29_January_05_53_23_PM).jpeg";
            var image = new SnapshotImage
            {
                Id = id,
                FilePath = imageUrl
            };
            var imageEntity = new EO.SnapshotImage
            {
                Id = id,
                FilePath = imageUrl
            };

            _snapshotUnitOfWorkMock.Setup(x => x.SnapshotRepository).Returns(_snapshotRepositoryMock.Object);
            _snapshotRepositoryMock.Setup(x => x.Add(It.Is<EO.SnapshotImage>(y => y.FilePath == imageEntity.FilePath))).Verifiable();
            _snapshotUnitOfWorkMock.Setup(x => x.Save()).Verifiable();
            //act
            _snapshotService.SnapshotCapturer();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _snapshotUnitOfWorkMock.VerifyAll(),
                () => _snapshotRepositoryMock.VerifyAll()
                );
        }
    }
}