using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Entities.Attributes;

namespace ModularMonolith.Products.Application.Abstraction;

public interface IProductModuleDbContext
{
    DbSet<Attribute> Attributes { get; }
    DbSet<Product> Products { get; }
    DbSet<Manufacturer> Manufacturers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}