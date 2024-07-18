
using AutoApp.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.DataAccess.Data.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly AutoAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemDeleted;
        public event EventHandler<T> ItemSaved;
        public DbRepository(AutoAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            _dbSet = _dbContext.Set<T>();
         }

        public T? GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemDeleted?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            ItemSaved?.Invoke(this, new());
        }
    }
}
