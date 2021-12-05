using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Cfd.Models
{
    public class CfdContext : DbContext
    {

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItem> CartItems { get; set; }
        public DbSet<Image> Images { get; set; }


        public CfdContext(DbContextOptions<CfdContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CfdContext;User ID=sa;Password=r22rbf8*PUHjqzb3",

            builder => builder.EnableRetryOnFailure());
        }

    }
}
