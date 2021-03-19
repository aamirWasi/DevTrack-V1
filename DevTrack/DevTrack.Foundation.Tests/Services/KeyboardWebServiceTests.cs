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
    public class KeyboardWebServiceTests
    {
        private AutoMock _mock;
        private Mock<IKeyboardWebUnitOfWork> _keyboardWebUnitMock;
        private Mock<IKeyboardWebRepository> _keyboardWebRepositoryMock;
        private IKeyboardWebService _keyboardWebService;


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
            _keyboardWebUnitMock = _mock.Mock<IKeyboardWebUnitOfWork>();
            _keyboardWebRepositoryMock = _mock.Mock<IKeyboardWebRepository>();
            _keyboardWebService = _mock.Create<KeyboardWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _keyboardWebRepositoryMock?.Reset();
            _keyboardWebUnitMock?.Reset();
        }


        [Test]
        public void SaveKeyboardIntoWeb_KeyboardProvide_SaveIntoSqlServer()
        {
            //arrange
            var keyboard = new Keyboard { A = 5, TotalKeyHits = 5 };
            //Keyboard keyboard = null;

            _keyboardWebUnitMock.Setup(x => x.KeyboardWebRepository)
                .Returns(_keyboardWebRepositoryMock.Object);

            _keyboardWebRepositoryMock.Setup(x => x.Add(keyboard)).Verifiable();
            _keyboardWebUnitMock.Setup(x => x.Save()).Verifiable();

            //act
            _keyboardWebService.SaveKeyboardIntoWeb(keyboard);

            //assert
            this.ShouldSatisfyAllConditions(
                () => _keyboardWebUnitMock.VerifyAll(),
                () => _keyboardWebRepositoryMock.VerifyAll()
            );
        }
    }
}