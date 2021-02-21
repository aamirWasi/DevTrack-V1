using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IMouseWebUnitOfWork : IUnitOfWork
    {

        IMouseWebRepository MouseWebRepository { get; set; }
    }
}