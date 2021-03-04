using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Repositories
{
    public class SettingsRepository : Repository<Settings, int, DevTrackProjectContext>, ISettingsRepository
    {
        public SettingsRepository(DevTrackProjectContext projectContext) : base(projectContext)
        {

        }
    }
}
