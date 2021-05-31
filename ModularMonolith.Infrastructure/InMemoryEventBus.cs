﻿using Microsoft.EntityFrameworkCore;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Outbox.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.Infrastructure
{
    public abstract class InMemoryEventBus : IEventBus
    {
        private readonly OutboxDbContext _dbContext;
        public InMemoryEventBus(OutboxDbContext dbContext)
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
            await _dbContext.OutBoxMessages.AddAsync(outBoxMessage);
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
