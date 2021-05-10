using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ModularMonolith.Contracts;
using ModularMonolith.Outbox;

namespace ModularMonolith.Core
{
    public class InMemoryEventBus : IEventBus
    {
        public async Task Publish(IIntegrationEvent @event)
        {
            var message = JsonSerializer.Serialize(@event);
            var type = @event.GetType();


        }
    }
}
