﻿
using AutoApp.Entities;

namespace AutoApp.Repositories.Extensions;
public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items) where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();
    }
}

