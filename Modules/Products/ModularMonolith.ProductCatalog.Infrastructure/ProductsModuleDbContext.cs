using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox.Persistence;
using ModularMonolith.ProductCatalog.Infrastructure.EntitiesConfigurations;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Entities.Attributes;

namespace ModularMonolith.ProductCatalog.Infrastructure;

public class ProductsModuleDbContext : OutboxDbContext, IProductModuleDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.HasDefaultSchema("pr");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Attribute> Attributes { get; set; }

    public ProductsModuleDbContext(DbContextOptions<ProductsModuleDbContext> options, IUserContext userContext) : base(options, userContext)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        SetAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }
}