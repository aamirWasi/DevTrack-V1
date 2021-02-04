﻿using Autofac.Extras.Moq;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Tests.Services
{
    public class ActiveProgramServiceTests
    {
        private AutoMock _mock;
        private Mock<IActiveProgramUnitOfWork> _activeProgramUnitOfWorkMock;
        private Mock<IActiveProgramRepository> _activeProgramRepositoryMock;
        private Mock<IActiveProgramAdapter> _activeProgramAdpaterMock;
        private ActiveProgramService _activeProgramService;

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
            _activeProgramRepositoryMock = _mock.Mock<IActiveProgramRepository>();
            _activeProgramUnitOfWorkMock = _mock.Mock<IActiveProgramUnitOfWork>();
            _activeProgramAdpaterMock = _mock.Mock<IActiveProgramAdapter>();
            _activeProgramService = _mock.Create<ActiveProgramService>();
        }

        [TearDown]
        public void Clean()
        {
            _activeProgramUnitOfWorkMock?.Reset();
            _activeProgramRepositoryMock?.Reset();
            _activeProgramAdpaterMock?.Reset();
        }

        [Test]
        public void SaveActiveProgram_NoProgramNameProvided_ThrowsInvalidOperationException()
        {
            //arrange
            string programName = null;
            _activeProgramAdpaterMock.Setup(x => x.GetActiveProgramName()).Returns(programName);

            //act
            Should.Throw<InvalidOperationException>(
                () => _activeProgramService.SaveActiveProgram()
                );

            //assert
            this.ShouldSatisfyAllConditions(
                () => _activeProgramAdpaterMock.VerifyAll()
                );
        }


        [Test]
        public void SaveActiveProgram_Save()
        {
            //arrange
            string programName = "Slack";
            
            var activeProgram = new ActiveProgram
            {
                ProgramName = programName,
                ProgramTime = DateTime.Now
            };

            _activeProgramAdpaterMock.Setup(x => x.GetActiveProgramName()).Returns(programName);

            _activeProgramUnitOfWorkMock.Setup(x => x.ActiveProgramRepository).Returns(_activeProgramRepositoryMock.Object);

            _activeProgramRepositoryMock.Setup(x => x.Add(It.Is<ActiveProgram>(y => y.ProgramName == activeProgram.ProgramName))).Verifiable();

            _activeProgramUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //act
            _activeProgramService.SaveActiveProgram();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _activeProgramAdpaterMock.VerifyAll()
                , () => _activeProgramUnitOfWorkMock.VerifyAll()
                , () => _activeProgramRepositoryMock.VerifyAll()
                );
        }
    }
}
