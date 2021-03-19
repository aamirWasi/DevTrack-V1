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

namespace DevTrack.Foundation.Tests.Services
{
    public class MouseTrackServiceTest
    {
        private AutoMock _mock;
        private Mock<IMouseTrackUnitOfWork> _mouseTrackUnitOfWorkMock;
        private Mock<IMouseTrackRepository> _mouseTrackRepositoryMock;
        private Mock<IMouseTrackStartService> _mouseTrackStartServiceMock;
        private IMouseTrackService _mouseTrackService;


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
            _mouseTrackUnitOfWorkMock = _mock.Mock<IMouseTrackUnitOfWork>();
            _mouseTrackRepositoryMock = _mock.Mock<IMouseTrackRepository>();
            _mouseTrackStartServiceMock = _mock.Mock<IMouseTrackStartService>();
            _mouseTrackService = _mock.Create<MouseTrackService>();
        }

        [TearDown]
        public void Clean()
        {
            _mouseTrackUnitOfWorkMock?.Reset();
            _mouseTrackRepositoryMock?.Reset();
            _mouseTrackStartServiceMock?.Reset();
        }


        [Test]
        public void MouseTrackSaveToLocal_MouseTrackProvided_SaveTrackInfo()
        {
            //arrange
            var mouse = new Mouse { LeftButtonClick = 1};
            //Mouse mouse = null;

            _mouseTrackStartServiceMock.Setup(x => x.MouseEntity()).Returns(mouse);
            _mouseTrackUnitOfWorkMock.Setup(x => x.MouseTrackRepository)
                .Returns(_mouseTrackRepositoryMock.Object);

            _mouseTrackRepositoryMock.Setup(x => x.Add(mouse)).Verifiable();
            _mouseTrackUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _mouseTrackService.MouseTrackSaveToLocal();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _mouseTrackUnitOfWorkMock.VerifyAll(),
                () => _mouseTrackRepositoryMock.VerifyAll(),
                () => _mouseTrackStartServiceMock.VerifyAll()
            );
        }
    }
}