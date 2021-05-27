using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Add(Entities.Product product);
        Task<Entities.Product> Get(Guid id, CancellationToken cancellationToken);
        Task Commit();
    }
}
