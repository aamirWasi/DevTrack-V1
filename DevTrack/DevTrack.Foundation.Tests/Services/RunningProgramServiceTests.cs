using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;

namespace DevTrack.Foundation.Tests.Services
{
    public class RunningProgramServiceTests
    {
        private AutoMock _mock;
        private Mock<IRunningProgramUnitOfWork> _runningProgramUnitOfWorkMock;
        private Mock<IRunningProgramRepository> _runningProgramRepositoryMock;
        private Mock<IRunningProgramAdapter> _runningProgramAdapterMock;
        private IRunningProgramService _runningProgramService;

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

        [Test]
        public void AddRunningProgramList_NoProgramListProvided_ThrowsInvalidOperationException()
        {
            //Arrange
            string appName = String.Empty;
            _runningProgramAdapterMock.Setup(x=>x.GetRunningPrograms()).Returns(appName);

            //Act
            Should.Throw<InvalidOperationException>(
                () => _runningProgramService.AddCurrentlyRunningPrograms()
                ) ;

            //Assert
            this.ShouldSatisfyAllConditions(
                ()=>_runningProgramAdapterMock.VerifyAll()
                );
        }

        [Test]
        public void AddRunningProgramList_ApplicationsFound_Save()
        {
            //Arrange 
            string appName = "chrome,Code,devenv,TopTracker";

            var runningApps = new RunningProgram
            {
                RunningApplications = appName,
                RunningApplicationsDateTime = DateTime.Now
            };

            _runningProgramUnitOfWorkMock.Setup(x => x.RunningProgramRepository).Returns(_runningProgramRepositoryMock.Object);
            _runningProgramAdapterMock.Setup(x=>x.GetRunningPrograms()).Returns(appName);
            _runningProgramRepositoryMock.Setup(x => x.Add(It.Is<RunningProgram>(y => y.RunningApplications == runningApps.RunningApplications))).Verifiable();
            _runningProgramUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //Act
            _runningProgramService.AddCurrentlyRunningPrograms();

            //Assert
            this.ShouldSatisfyAllConditions(
                () => _runningProgramAdapterMock.VerifyAll(),
                () => _runningProgramRepositoryMock.VerifyAll(),
                () => _runningProgramUnitOfWorkMock.VerifyAll()
                ) ;
        }
    }
}
