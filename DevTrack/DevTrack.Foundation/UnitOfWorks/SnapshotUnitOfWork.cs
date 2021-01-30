using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class SnapshotUnitOfWork : UnitOfWork, ISnapshotUnitOfWork
    {
        public SnapshotUnitOfWork(ScreenCaptureContext screenCapturerContext, ISnapshotRepository snapshotRepository) : base(screenCapturerContext)
        {
            SnapshotRepository = snapshotRepository;
        }

        public ISnapshotRepository SnapshotRepository { get; set; }
    }
}
