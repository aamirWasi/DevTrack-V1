using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Repositories
{
    public class SettingsRepository : Repository<Settings, int, DevTrackWebContext>, ISettingsRepository
    {
        public SettingsRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}
