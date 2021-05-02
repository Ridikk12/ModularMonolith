using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ModularMonolith.History.Domain;

namespace ModularMonolith.History.Infrastructure
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
            await _dbContext.SaveChangesAsync();
        }
    }
}
