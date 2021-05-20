using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Outbox.Persistence;

public static class OutBoxModuleStartup
{
    public static IServiceCollection AddOutBoxModule(
        this IServiceCollection services)
    {
        services.AddDbContext<OutboxDbContext>();
        return services;
    }
}