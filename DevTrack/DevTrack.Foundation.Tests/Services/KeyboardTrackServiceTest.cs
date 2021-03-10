using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    public class KeyboardTrackServiceTest
    {
        private AutoMock _mock;
        private Mock<IKeyboardTrackUnitOfWork> _keyboardTrackUnitMock;
        private Mock<IKeyboardWebUnitOfWork> _keyboardWebUnitMock;
        private Mock<IKeyboardTrackRepository> _keyboardTrackRepositoryMock;
        private Mock<IKeyboardWebRepository> _keyboardWebRepositoryMock;
        private Mock<IKeyboardTrackStartService> _keyboardTrackStartService;
        private IKeyboardWebService _keyboardWebService;
        private IKeyboardTrackService _keyboardTrackService;


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
            _keyboardTrackUnitMock = _mock.Mock<IKeyboardTrackUnitOfWork>();
            _keyboardWebUnitMock = _mock.Mock<IKeyboardWebUnitOfWork>();
            _keyboardTrackRepositoryMock = _mock.Mock<IKeyboardTrackRepository>();
            _keyboardTrackStartService = _mock.Mock<IKeyboardTrackStartService>();
            _keyboardWebRepositoryMock = _mock.Mock<IKeyboardWebRepository>();
            _keyboardWebService = _mock.Create<KeyboardWebService>();
            _keyboardTrackService = _mock.Create<KeyboardTrackService>();
        }

        [TearDown]
        public void Clean()
        {
            _keyboardTrackUnitMock?.Reset();
            _keyboardTrackRepositoryMock?.Reset();
            _keyboardTrackStartService?.Reset();
            _keyboardWebRepositoryMock?.Reset();
            _keyboardWebUnitMock?.Reset();
        }


        [Test]
        public void KeyboardTrackSaveToLocal_KeyboardTrackDataSet_SaveTrackInfo()
        {
            //arrange
            var keyboard = new Keyboard{A = 5, TotalKeyHits = 5};
            //Keyboard keyboard = null;

            _keyboardTrackStartService.Setup(x => x.KeyboardEntity()).Returns(keyboard);
            _keyboardTrackUnitMock.Setup(x => x.KeyboardTrackRepository)
                .Returns(_keyboardTrackRepositoryMock.Object);

            _keyboardTrackRepositoryMock.Setup(x => x.Add(keyboard)).Verifiable();
            _keyboardTrackUnitMock.Setup(x => x.Save()).Verifiable();

            //act
            _keyboardTrackService.KeyboardTrackSaveToLocal();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _keyboardTrackUnitMock.VerifyAll(),
                () => _keyboardTrackRepositoryMock.VerifyAll(),
                () => _keyboardTrackStartService.VerifyAll()
            );
        }

        [Test]
        public void SaveKeyboardIntoWeb_KeyboardProvide_SaveIntoSqlServer()
        {
            //arrange
            var keyboard = new Keyboard{A = 5, TotalKeyHits = 5};
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