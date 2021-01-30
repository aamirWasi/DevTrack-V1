using System;

namespace DevTrack.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
