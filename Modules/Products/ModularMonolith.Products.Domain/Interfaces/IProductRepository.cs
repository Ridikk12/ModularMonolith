using System;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<Product> Get(Guid id, CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
