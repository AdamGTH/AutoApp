using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoApp.Entities;

namespace AutoApp.Data
{
    public class AutoAppDbContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<ElectricCar> ElectricCar => Set<ElectricCar>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
