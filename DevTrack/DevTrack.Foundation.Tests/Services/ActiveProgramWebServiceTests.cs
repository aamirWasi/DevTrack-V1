using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Tests.Services
{
    public class ActiveProgramWebServiceTests
    {
        private AutoMock _mock;
        private Mock<IActiveProgramWebUnitOfWork> _activeProgramWebUnitMock;
        private Mock<IActiveProgramWebRepository> _activeProgramWebRepositoryMock;
        private IActiveProgramWebService _activeProgramWebService;


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
            _activeProgramWebUnitMock = _mock.Mock<IActiveProgramWebUnitOfWork>();
            _activeProgramWebRepositoryMock = _mock.Mock<IActiveProgramWebRepository>();
            _activeProgramWebService = _mock.Create<ActiveProgramWebService>();
        }

        [TearDown]
        public void Clean()
        {
            _activeProgramWebRepositoryMock?.Reset();
            _activeProgramWebUnitMock?.Reset();
        }

        [Test]
        public void SaveActiveProgramIntoWeb_NoProgramProvided_ThrowsInvalidOperationException()
        {
            //arrange
            var program = new ActiveProgram { ProgramName = "Slack", ProgramTime = DateTime.Now };
            ActiveProgram activeProgram = null;

            //act
            Should.Throw<InvalidOperationException>(
                () => _activeProgramWebService.SaveActiveProgramWebDb(activeProgram)
                );

            //assert
            activeProgram.ShouldNotBe(program);
        }


        [Test]
        public void SaveActiveProgramIntoWeb_ProgramProvide_SaveIntoSqlServer()
        {
            //arrange
            var program = new ActiveProgram { ProgramName = "Slack", ProgramTime = DateTime.Now };

            _activeProgramWebUnitMock.Setup(x => x.ActiveProgramWebRepository)
                .Returns(_activeProgramWebRepositoryMock.Object);

            _activeProgramWebRepositoryMock.Setup(x => x.Add(program)).Verifiable();
            _activeProgramWebUnitMock.Setup(x => x.Save()).Verifiable();

            //act
            _activeProgramWebService.SaveActiveProgramWebDb(program);

            //assert
            this.ShouldSatisfyAllConditions(
                () => _activeProgramWebUnitMock.VerifyAll(),
                () => _activeProgramWebRepositoryMock.VerifyAll()
            );
        }
    }
}
