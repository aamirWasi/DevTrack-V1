using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IActiveProgramService
    {
        void SaveActiveProgramLocalDb();
        void SyncActivePrograms();
    }
}
