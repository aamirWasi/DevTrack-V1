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
    public class MouseWebServiceTests
    {
        private AutoMock _mock;
        private Mock<IMouseWebUnitOfWork> _mouseWebUnitOfWorkMock;
        private Mock<IMouseWebRepository> _mouseWebRepositoryMock;
        private IMouseWebService _mouseWebService;


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
            _mouseWebUnitOfWorkMock = _mock.Mock<IMouseWebUnitOfWork>();
            _mouseWebRepositoryMock = _mock.Mock<IMouseWebRepository>();
            _mouseWebService = _mock.Create<MouseWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _mouseWebUnitOfWorkMock?.Reset();
            _mouseWebRepositoryMock?.Reset();
        }


        [Test]
        public void SaveMouseIntoWeb_MouseNotNull_SaveIntoSqlServer()
        {
            //arrange
            var mouse = new Mouse { LeftButtonClick = 1};
            //Mouse mouse = null;
            _mouseWebUnitOfWorkMock.Setup(x => x.MouseWebRepository)
                .Returns(_mouseWebRepositoryMock.Object);

            _mouseWebRepositoryMock.Setup(x => x.Add(mouse)).Verifiable();
            _mouseWebUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _mouseWebService.SaveMouseIntoWeb(mouse);

            //assert
            this.ShouldSatisfyAllConditions(
                () => _mouseWebUnitOfWorkMock.VerifyAll(),
                () => _mouseWebRepositoryMock.VerifyAll()
            );
        }
    }
}