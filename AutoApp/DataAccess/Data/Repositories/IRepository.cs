
using AutoApp.DataAccess.Data.Entities;

namespace AutoApp.DataAccess.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
         event EventHandler<T> ItemAdded;
         event EventHandler<T> ItemDeleted;
         event EventHandler<T> ItemSaved;
    }
}
