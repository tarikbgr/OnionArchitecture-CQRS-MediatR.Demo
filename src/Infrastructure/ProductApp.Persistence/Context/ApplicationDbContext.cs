using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {   

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "MackBook", Value = 16999, Quantity = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Dell", Value = 14000, Quantity = 22 },
                new Product { Id = Guid.NewGuid(), Name = "Hp", Value = 12000, Quantity = 38 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
