using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.History.Domain
{
    public interface IHistoryEntityRepository
    {
        Task<List<EntityHistory>> Get(Guid productId, CancellationToken cancellationToken);
        Task Add(EntityHistory history);
    }
}