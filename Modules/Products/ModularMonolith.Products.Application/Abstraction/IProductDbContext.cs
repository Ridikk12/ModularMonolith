using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Application.Abstraction;

public interface IProductModuleDbContext
{
    DbSet<InventoryProduct> InventoryProducts { get; set; }
    DbSet<Location> Locations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}