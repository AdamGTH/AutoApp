﻿using AutoApp.Data.Entities;

namespace AutoApp.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
         event EventHandler<T> ItemAdded;
         event EventHandler<T> ItemDeleted;
         event EventHandler<T> ItemSaved;
    }
}
