using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.Contracts;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Outbox.Entities;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.Outbox
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly OutboxDbContext _dbContext;

        public InMemoryEventBus(OutboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Publish(IIntegrationEvent @event)
        {

            await PersistIntegrationEvent(@event);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task PublishMany(IEnumerable<IIntegrationEvent> @events)

        {
            foreach (var @event in @events)
            {
                await PersistIntegrationEvent(@event);
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        private async Task PersistIntegrationEvent(IIntegrationEvent @event)
        {
            var message = JsonSerializer.Serialize(@event, @event.GetType());
            var type = @event.GetType().ToString();

            var outBoxMessage = OutBoxMessage.New(message, type);

            await _dbContext.OutBoxMessages.AddAsync(outBoxMessage);
        }
    }
}
