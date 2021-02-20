﻿using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class ActiveProgramWebUnitOfWork : UnitOfWork, IActiveProgramWebUnitOfWork
    {
        public ActiveProgramWebUnitOfWork(DevTrackWebContext activeProgramWebContext, IActiveProgramWebRepository activeProgramWebRepository) : base(activeProgramWebContext)
        {
            ActiveProgramWebRepository = activeProgramWebRepository;
        }

        public IActiveProgramWebRepository ActiveProgramWebRepository { get; set; }
    }
}