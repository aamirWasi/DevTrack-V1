using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IActiveProgramUnitOfWork : IUnitOfWork
    {
        IActiveProgramRepository ActiveProgramRepository { get; set; }
    }
}
