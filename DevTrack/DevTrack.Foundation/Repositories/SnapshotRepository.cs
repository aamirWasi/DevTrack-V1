using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.Repositories
{
    public class SnapshotRepository : Repository<SnapshotImage, int, ScreenCaptureContext>, ISnapshotRepository
    {
        public SnapshotRepository(ScreenCaptureContext shoppingContext) : base(shoppingContext)
        {

        }
    }
}
