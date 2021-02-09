using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Entities;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    public class KeyboardTrackAdapterTest
    {
        private AutoMock _mock;
        private Mock<IKeyboardTrackAdapter> _keyboardTrackAdapterMock;
        private IKeyboardTrackAdapter _keyboardTrackAdapter;

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
            _keyboardTrackAdapterMock = _mock.Mock<IKeyboardTrackAdapter>();
            _keyboardTrackAdapter = _mock.Create<KeyboardTrackAdapter>();
        }

        [TearDown]
        public void Clean()
        {
            _keyboardTrackAdapterMock.Reset();
        }


        [Test]
        public void KeyboardEntity_FirstTime_ProvideNull()
        {
            //arrange
            _keyboardTrackAdapter.IsFirst = true;

            //act
            var result = _keyboardTrackAdapter.KeyboardEntity();

            //assert
            result.ShouldBeNull();
        }
        
        
        //[Test]
        //public void KeyboardEntity_FirstTime_ProvideNull()
        //{
        //    //arrange
        //    Keyboard keyboard = null;
        //    _keyboardTrackAdapterMock.Setup(x => x.IsFirst)
        //        .Returns(false);

        //    //act
        //    _keyboardTrackAdapterMock.Setup(x => x.KeyboardEntity())
        //        .Returns(keyboard).Verifiable();

        //    //assert
        //    _keyboardTrackAdapterMock.VerifyAll();
        //}
    }
}
