﻿using System;
using Autofac.Extras.Moq;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace DevTrack.Foundation.Tests.Services
{
    public class KeyboardTrackServiceTest
    {
        private AutoMock _mock;
        private Mock<IKeyboardTrackUnitOfWork> _keyboardTrackUnitMock;
        private Mock<IKeyboardTrackRepository> _keyboardTrackRepositoryMock;
        private Mock<IKeyboardTrackAdapter> _keyboardTrackAdapter;
        private IKeyboardTrackService _keyboardTrackService;


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
            _keyboardTrackUnitMock = _mock.Mock<IKeyboardTrackUnitOfWork>();
            _keyboardTrackRepositoryMock = _mock.Mock<IKeyboardTrackRepository>();
            _keyboardTrackAdapter = _mock.Mock<IKeyboardTrackAdapter>();
            _keyboardTrackService = _mock.Create<KeyboardTrackService>();
        }

        [TearDown]
        public void Clean()
        {
            _keyboardTrackUnitMock?.Reset();
            _keyboardTrackRepositoryMock?.Reset();
            _keyboardTrackAdapter?.Reset();
        }


        [Test]
        public void KeyboardTrackSave_KeyboardTrackProvided_SaveTrackInfo()
        {
            //arrange
            var keyboard = new Keyboard{A = 5, TotalKeyHits = 5};
            _keyboardTrackAdapter.Setup(x => x.KeyboardEntity()).Returns(keyboard);
            _keyboardTrackUnitMock.Setup(x => x.KeyboardTrackRepository)
                .Returns(_keyboardTrackRepositoryMock.Object);
            _keyboardTrackRepositoryMock.Setup(x => x.Add(keyboard)).Verifiable();
            _keyboardTrackUnitMock.Setup(x => x.Save()).Verifiable();

            //act
            _keyboardTrackService.KeyboardTrackSave();

            //assert
            this.ShouldSatisfyAllConditions(
                () => _keyboardTrackUnitMock.VerifyAll(),
                () => _keyboardTrackRepositoryMock.VerifyAll(),
                () => _keyboardTrackAdapter.VerifyAll()
            );
        }
    }
}