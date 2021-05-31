using System;
using System.Collections.Generic;
using System.Text;
using ModularMonolith.Contracts.Events;
using ModularMonolith.History.Application.EventBus;
using ModularMonolith.Infrastructure;
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
