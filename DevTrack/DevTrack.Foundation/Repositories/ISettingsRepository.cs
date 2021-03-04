﻿using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public interface ISettingsRepository : IRepository<Settings, int, DevTrackProjectContext>
    {
    }
}