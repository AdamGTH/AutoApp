using AutoApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Data.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly AutoAppDbContext<T> _dbContext;
        
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemDeleted;
        public event EventHandler<T> ItemSaved;
        public DbRepository(AutoAppDbContext<T> dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            
        }

        public T? GetByName(string name)
        {
            return _dbContext.Items.FirstOrDefault(x => x.Name == name);
        }
        public T? GetById(int id)
        {
            return _dbContext.Items.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Items.ToList();
        }
        public void Add(T item)
        {
            _dbContext.Items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbContext.Items.Remove(item);
            ItemDeleted?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            ItemSaved?.Invoke(this, new());
        }
    }
}
