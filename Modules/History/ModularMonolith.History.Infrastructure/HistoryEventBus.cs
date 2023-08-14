using ModularMonolith.History.Application.EventBus;
using ModularMonolith.Outbox;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.History.Infrastructure
{
    public class HistoryEventBus : InMemoryEventBus, IHistoryEventBus
    {
        public HistoryEventBus(OutboxDbContext dbContext) : base(dbContext)
        {
        }
    }
}
