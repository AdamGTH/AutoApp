using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoApp.Data.Entities;

namespace AutoApp.Data
{
    public class AutoAppDbContext<T> : DbContext where T : class, IEntity
    {
        public AutoAppDbContext(DbContextOptions<AutoAppDbContext<T>> options) 
            : base(options) 
        {

        }
        public DbSet<T> Items { get; set; }
    }
}
