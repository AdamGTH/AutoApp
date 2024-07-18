using System;
using System.Collections.Generic;
using AutoApp.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace AutoApp.DataAccess.Data
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
