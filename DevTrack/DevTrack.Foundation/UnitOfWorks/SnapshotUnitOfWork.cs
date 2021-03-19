using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class SnapshotUnitOfWork : UnitOfWork, ISnapshotUnitOfWork
    {
        public SnapshotUnitOfWork(DevTrackContext screenCapturerContext, ISnapshotRepository snapshotRepository) : base(screenCapturerContext)
        {
            SnapshotRepository = snapshotRepository;
        }

        public ISnapshotRepository SnapshotRepository { get; set; }
    }
}
