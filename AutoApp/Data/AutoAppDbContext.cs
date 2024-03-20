using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
