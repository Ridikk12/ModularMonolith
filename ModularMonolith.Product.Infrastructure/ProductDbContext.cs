using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Product.Domain;
using ModularMonolith.Product.Infrastructure.Configurations;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=ModularMonolith;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration).Assembly);
            modelBuilder.HasDefaultSchema("pr");
        }

        public DbSet<Domain.Product> Products { get; set; }
    }
}
