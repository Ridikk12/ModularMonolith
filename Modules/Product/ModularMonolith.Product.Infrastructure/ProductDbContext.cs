using Microsoft.EntityFrameworkCore;
using ModularMonolith.Outbox.Persistence;
using ModularMonolith.Product.Infrastructure.EntitiesConfigurations;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductDbContext : OutboxDbContext
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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Domain.Entities.Product> Products { get; set; }
    }
}
