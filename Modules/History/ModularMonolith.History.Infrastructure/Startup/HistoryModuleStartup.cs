using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.History.Application.EventBus;
using ModularMonolith.History.Application.Queries;
using ModularMonolith.History.Application.Queries.GetHistory;
using ModularMonolith.History.Domain.Interfaces;

namespace ModularMonolith.History.Infrastructure.Startup
{
    public static class HistoryModuleStartup
    {
        public static IServiceCollection AddHistoryModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetHistoryQuery));
            services.AddDbContext<HistoryDbContext>(x =>
            {
                var connectionString = configuration["Modules:HistoryModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });
            services.AddScoped<IHistoryEntityRepository, EntityHistoryRepository>();
            services.AddScoped<IHistoryEventBus, HistoryEventBus>();
            return services;
        }
    }
}

