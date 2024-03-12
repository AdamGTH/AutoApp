using AutoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Data.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        public void Add(T item);
        public void Remove(T item);
        public void Save();
    }
}
