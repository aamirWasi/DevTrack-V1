using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    public class KeyboardTrackAdapterTest
    {
        private AutoMock _mock;
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
            _keyboardTrackAdapter = _mock.Create<KeyboardTrackAdapter>();
        }

        [TearDown]
        public void Clean()
        {
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
    }
}
