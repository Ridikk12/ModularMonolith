using System.Threading.Tasks;
using ModularMonolith.Contracts;

namespace ModularMonolith.Outbox
{
    public interface IEventBus
    {
        public Task Publish(IIntegrationEvent @event);
    }
}
