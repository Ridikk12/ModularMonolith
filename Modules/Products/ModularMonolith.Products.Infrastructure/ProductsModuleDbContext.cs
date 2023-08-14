using Microsoft.EntityFrameworkCore;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox.Persistence;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Infrastructure.EntitiesConfigurations;

namespace ModularMonolith.Products.Infrastructure
{
    public class ProductsModuleDbContext : OutboxDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.HasDefaultSchema("pr");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public ProductsModuleDbContext(DbContextOptions<ProductsModuleDbContext> options, IUserContext userContext) : base(options, userContext)
        {

        }
        
    }
}
