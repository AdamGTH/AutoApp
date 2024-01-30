﻿using AutoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>  where T : class, IEntity
    {
    }
}
