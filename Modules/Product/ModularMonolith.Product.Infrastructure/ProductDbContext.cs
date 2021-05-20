using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Product.Domain;
using ModularMonolith.Product.Infrastructure.EntitiesConfigurations;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.HasDefaultSchema("pr");
        }

        public DbSet<Domain.Entities.Product> Products { get; set; }
    }
}
