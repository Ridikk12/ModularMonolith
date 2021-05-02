using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.History.Application;
using ModularMonolith.History.Application.Queries;
using ModularMonolith.History.Domain;
using ModularMonolith.History.Domain.Interfaces;

namespace ModularMonolith.History.Infrastructure.Startup
{
    public static class HistoryModuleStartup
    {
        public static IServiceCollection AddHistoryModule(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetHistoryQuery));
            services.AddDbContext<HistoryDbContext>();
            services.AddScoped<IHistoryEntityRepository, EntityHistoryRepository>();
            return services;
        }
    }
}

