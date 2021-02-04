using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IActiveProgramUnitOfWork : IUnitOfWork
    {
        IActiveProgramRepository ActiveProgramRepository { get; set; }
    }
}
