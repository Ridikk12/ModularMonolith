using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Infrastructure;

namespace ModularMonolith.Configs
{
    public static class EventBusConfiguration
    {
        public static IServiceCollection AddInMemoryEventBus(
            this IServiceCollection services)
        {
            services.AddScoped<IEventBus, InMemoryEventBus>();
            return services;
        }
    }
}
