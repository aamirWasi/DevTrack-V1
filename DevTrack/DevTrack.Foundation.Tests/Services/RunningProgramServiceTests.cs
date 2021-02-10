using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Tests.Services
{
    public class RunningProgramServiceTests
    {
        private AutoMock _mock;
        private Mock<IRunningProgramUnitOfWork> _runningProgramUnitOfWorkMock;
        private Mock<IRunningProgramRepository> _runningProgramRepositoryMock;
        private Mock<IRunningProgramAdapter> _runningProgramAdapterMock;
        private RunningProgramService _runningProgramService;

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
            _runningProgramUnitOfWorkMock = _mock.Mock<IRunningProgramUnitOfWork>();
            _runningProgramRepositoryMock = _mock.Mock<IRunningProgramRepository>();
            _runningProgramAdapterMock = _mock.Mock<IRunningProgramAdapter>();
            _runningProgramService = _mock.Create<RunningProgramService>();
        }

        [TearDown]
        public void Clean()
        {
            _runningProgramUnitOfWorkMock?.Reset();
            _runningProgramRepositoryMock?.Reset();
            _runningProgramAdapterMock?.Reset();
        }
    }
}
