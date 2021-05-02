using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.Product.Domain
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<Product> Get(Guid id, CancellationToken cancellationToken);
    }
}
