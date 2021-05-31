using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.History.Domain.Entities;

namespace ModularMonolith.History.Domain.Interfaces
{
    public interface IHistoryEntityRepository
    {
        Task<List<EntityHistory>> Get(Guid productId, CancellationToken cancellationToken);
        Task Add(EntityHistory history);
        Task<int> CommitAsync();
    }
}