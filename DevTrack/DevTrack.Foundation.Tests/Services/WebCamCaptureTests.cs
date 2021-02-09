 using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using NUnit.Framework;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Adapters;
using Shouldly;
using Moq;
using DevTrack.Foundation.Services;

namespace DevTrack.Foundation.Tests.Services
{
    class WebCamCaptureTests
    {
        private AutoMock _mock;
        private Mock<IWebCamCaptureUnitOfWork> _webCamCaptureUnitOfWorkMock;
        private Mock<IWebCamCaptureRepository> _webCamCaptureRepositoryMock;
        private Mock<IWebCamImageAdapter> _webCamImageAdapterMock;
        private WebCamCaptureService _webCamCaptureService;

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
            _webCamCaptureRepositoryMock = _mock.Mock<IWebCamCaptureRepository>();
            _webCamCaptureUnitOfWorkMock = _mock.Mock<IWebCamCaptureUnitOfWork>();
            _webCamImageAdapterMock = _mock.Mock<IWebCamImageAdapter>();
            _webCamCaptureService = _mock.Create<WebCamCaptureService>();
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
