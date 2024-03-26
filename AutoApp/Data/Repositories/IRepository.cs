using AutoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
         event EventHandler<T> ItemAdded;
         event EventHandler<T> ItemDeleted;
         event EventHandler<T> ItemSaved;
    }
}
