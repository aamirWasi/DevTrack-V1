using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IKeyboardWebUnitOfWork : IUnitOfWork
    {
        IKeyboardWebRepository KeyboardWebRepository { get; set; }
    }
}