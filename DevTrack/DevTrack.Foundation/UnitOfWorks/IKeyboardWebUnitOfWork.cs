﻿using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IKeyboardWebUnitOfWork : IUnitOfWork
    {
        IKeyboardWebRepository KeyboardWebRepository { get; set; }
    }
}