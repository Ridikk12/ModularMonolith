using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModularMonolith.Contracts.Events
{
    public interface IEventBus
    {
        public Task Publish(IIntegrationEvent @event);
        Task PublishMany(IEnumerable<IIntegrationEvent> @events);
    }
}
