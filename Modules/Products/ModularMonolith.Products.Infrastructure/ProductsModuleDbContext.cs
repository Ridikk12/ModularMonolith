using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox.Persistence;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Infrastructure.EntitiesConfigurations;

namespace ModularMonolith.Products.Infrastructure
{
    public class ProductsModuleDbContext : OutboxDbContext, IProductModuleDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.HasDefaultSchema("pr");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
        public DbSet<Location> Locations { get; set; }

        public ProductsModuleDbContext(DbContextOptions<ProductsModuleDbContext> options, IUserContext userContext) : base(options, userContext)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
