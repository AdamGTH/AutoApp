using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoApp.Data.Entities;

namespace AutoApp.Data
{
    public class AutoAppDbContext : DbContext
    {
        public AutoAppDbContext(DbContextOptions<AutoAppDbContext> options) 
            : base(options) 
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
