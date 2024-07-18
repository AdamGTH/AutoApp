using AutoApp.DataAccess.Data.Entities;


namespace AutoApp.DataAccess.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public T GetByName(string id);
    }
}
