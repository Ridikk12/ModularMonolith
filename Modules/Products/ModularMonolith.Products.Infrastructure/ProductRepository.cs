using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Interfaces;

namespace ModularMonolith.Products.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsModuleDbContext _dbContext;
        public ProductRepository(ProductsModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Domain.Entities.Product product)
        {
            await _dbContext.AddAsync(product);
        }

        public Task<Product> Get(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
