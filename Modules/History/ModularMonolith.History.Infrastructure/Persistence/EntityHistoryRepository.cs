using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.History.Domain.Entities;
using ModularMonolith.History.Domain.Interfaces;

namespace ModularMonolith.History.Infrastructure.Persistence
{
    public class EntityHistoryRepository : IHistoryEntityRepository
    {
        private readonly HistoryDbContext _dbContext;

        public EntityHistoryRepository(HistoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<EntityHistory>> Get(Guid productId, CancellationToken cancellationToken)
        {
            return _dbContext.EntityHistories.Where(x => x.EntityId == productId).ToListAsync(cancellationToken);
        }

        public async Task Add(EntityHistory history)
        {
            await _dbContext.EntityHistories.AddAsync(history);
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
