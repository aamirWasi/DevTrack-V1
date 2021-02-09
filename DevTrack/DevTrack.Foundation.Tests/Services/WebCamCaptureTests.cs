 using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    class WebCamCaptureTests
    {
        private AutoMock _mock;

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

        }

        [TearDown]
        public void Clean()
        {

        }

        [Test]
        public void WebCamCaptureImageSave_NoImageFound()
        {
            //arrange


            //act


            //assert

        }
    }
}
