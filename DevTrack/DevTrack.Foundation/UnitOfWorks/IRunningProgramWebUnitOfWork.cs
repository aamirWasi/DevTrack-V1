using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IRunningProgramWebUnitOfWork : IUnitOfWork
    {
        IRunningProgramWebRepository RunningProgramWebRepository { get; set; }
    }
}
