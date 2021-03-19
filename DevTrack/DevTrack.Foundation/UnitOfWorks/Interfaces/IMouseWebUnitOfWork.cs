using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IMouseWebUnitOfWork : IUnitOfWork
    {

        IMouseWebRepository MouseWebRepository { get; set; }
    }
}