using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using EO = DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Tests.Services
{
    public class RunningProgramWebServiceTests
    {
        private AutoMock _mock;
        private Mock<IRunningProgramWebUnitOfWork> _runningProgramWebUnitOfWorkMock;
        private Mock<IRunningProgramWebRepository> _runningProgramWebRepositoryMock;
        private IRunningProgramWebService _runningProgramWebService;

        [OneTimeSetUp]
        public void ClasssTestUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanUp()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _runningProgramWebUnitOfWorkMock = _mock.Mock<IRunningProgramWebUnitOfWork>();
            _runningProgramWebRepositoryMock = _mock.Mock<IRunningProgramWebRepository>();
            _runningProgramWebService = _mock.Create<RunningProgramWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _runningProgramWebUnitOfWorkMock?.Reset();
            _runningProgramWebRepositoryMock?.Reset();
        }
    }
}
