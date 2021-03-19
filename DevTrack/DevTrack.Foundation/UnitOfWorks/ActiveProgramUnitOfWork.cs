using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class ActiveProgramUnitOfWork : UnitOfWork, IActiveProgramUnitOfWork
    {
        public ActiveProgramUnitOfWork(DevTrackContext activeProgramContext, IActiveProgramRepository activeProgramRepository) : base(activeProgramContext)
        {
            ActiveProgramRepository = activeProgramRepository;
        }

        public IActiveProgramRepository ActiveProgramRepository { get; set; }
    }
}
