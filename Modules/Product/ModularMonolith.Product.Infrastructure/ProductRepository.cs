using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Infrastructure;
using ModularMonolith.Product.Domain;
using ModularMonolith.Product.Domain.Interfaces;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Domain.Entities.Product product)
        {
            await _dbContext.AddAsync(product);
        }

        public Task<Domain.Entities.Product> Get(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task Commit()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
