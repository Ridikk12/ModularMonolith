using Microsoft.EntityFrameworkCore;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Outbox.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly DbContext _dbContext;
        public InMemoryEventBus(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Publish(IIntegrationEvent @event)
        {
            await PersistIntegrationEvent(@event);
        }

        private async Task PersistIntegrationEvent(IIntegrationEvent @event)
        {
            var outBoxMessage = OutBoxMessage.New(@event);
            await _dbContext.Set<OutBoxMessage>().AddAsync(outBoxMessage);
        }
        public async Task PublishMany(IEnumerable<IIntegrationEvent> @events)

        {
            foreach (var @event in @events)
            {
                await PersistIntegrationEvent(@event);
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
