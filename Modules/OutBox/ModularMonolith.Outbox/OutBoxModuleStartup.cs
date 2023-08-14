using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Infrastructure.Persistence;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.Outbox
{
    public static class OutBoxModuleStartup
    {
        public static IServiceCollection AddOutBoxModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OutboxDbContext>(x =>
            {
                var connectionString = configuration["Modules:OutBoxModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });
            
            return services;
        }
    }
}