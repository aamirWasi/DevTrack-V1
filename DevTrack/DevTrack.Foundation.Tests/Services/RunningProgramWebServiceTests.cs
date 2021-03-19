using System;
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

        [Test,Category("Unit Test")]
        public void AddRunningProgramsWebDb_ApplicationsAbsent_ThrowsException()
        {
            //Arrange
            string appName = String.Empty;

            var runningApps = new RunningProgram
            {
                RunningApplications = appName,
                RunningApplicationsDateTime = DateTime.Now
            };

            //Act & Assert
            Should.Throw<NullReferenceException>(
                () => _runningProgramWebService.AddRunningProgramsWebDb(runningApps)
            );
        }

        [Test,Category("Unit Test")]
        public void AddRunningProgramsWebDb_ProgramsFound_SaveToWeb()
        {
            //Arrange
            var runningApps = new EO.RunningProgram();

            _runningProgramWebUnitOfWorkMock.Setup(x => x.RunningProgramWebRepository).Returns(_runningProgramWebRepositoryMock.Object);
            _runningProgramWebRepositoryMock.Setup(x => x.Add(runningApps)).Verifiable();
            _runningProgramWebUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //Act
            _runningProgramWebService.AddRunningProgramsWebDb(runningApps);

            //Assert
            this.ShouldSatisfyAllConditions(
                () => _runningProgramWebUnitOfWorkMock.VerifyAll(),
                () => _runningProgramWebRepositoryMock.VerifyAll()
            );
        }
    }
}
