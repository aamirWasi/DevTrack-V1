using Microsoft.EntityFrameworkCore;

namespace DevTrack.DataAccessLayer
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context?.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
