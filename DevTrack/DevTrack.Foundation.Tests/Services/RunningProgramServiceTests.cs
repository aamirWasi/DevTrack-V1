using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
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
using System;
using System.Collections.Generic;

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

        [Test,Category("Unit Test")]
        public void AddRunningProgramsLocalDb_NoApplicationsFound_ThrowsInvalidOperationException()
        {
            //Arrange
            string appName = String.Empty;
            _runningProgramAdapterMock.Setup(x=>x.GetRunningPrograms()).Returns(appName);

            //Act
            Should.Throw<InvalidOperationException>(
                () => _runningProgramService.AddRunningProgramsLocalDb()
                ) ;

            //Assert
            this.ShouldSatisfyAllConditions(
                ()=>_runningProgramAdapterMock.VerifyAll()
                );
        }

        [Test,Category("Unit Test")]
        public void AddRunningProgramsLocalDb_ApplicationsFound_SaveApplications()
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
            _runningProgramService.AddRunningProgramsLocalDb();

            //Assert
            this.ShouldSatisfyAllConditions(
                () => _runningProgramAdapterMock.VerifyAll(),
                () => _runningProgramRepositoryMock.VerifyAll(),
                () => _runningProgramUnitOfWorkMock.VerifyAll()
                ) ;
        }

        [Test,Category("Unit Test")]
        public void SyncRunningPrograms_RunningAppListIsEmpty_ThrowException()
        {
            //Arrange
            List<RunningProgram> appList = null;

            _runningProgramUnitOfWorkMock.Setup(x => x.RunningProgramRepository).Returns(_runningProgramRepositoryMock.Object);
            _runningProgramRepositoryMock.Setup(x => x.GetAll()).Returns(appList).Verifiable();

            //Act
            Should.Throw<NullReferenceException>(
                () => _runningProgramService.SyncRunningPrograms()
            );

            //Assert
            this.ShouldSatisfyAllConditions(
                () => _runningProgramRepositoryMock.VerifyAll(),
                () => _runningProgramUnitOfWorkMock.VerifyAll()
            );
        }
    }
}
