using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Infrastructure;
using ModularMonolith.Providers;

namespace ModularMonolith.Configs
{
    public static class EventBusConfiguration
    {
        private const string ControllerRouteVariableName = "controller";
        public static IServiceCollection AddInMemoryEventBus(
            this IServiceCollection services)
        {
            services.AddScoped<IEventBus, InMemoryEventBus>(serviceProvider => {
                var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

                if (httpContextAccessor is null) {
                    throw new ArgumentNullException(nameof(httpContextAccessor));
                }
                var dbContextProvider = serviceProvider.GetService<IDbContextProvider>();

                if (dbContextProvider is null) {
                    throw new ArgumentNullException(nameof(dbContextProvider));
                }

                var controller = httpContextAccessor.HttpContext.GetRouteData().Values[ControllerRouteVariableName].ToString();

                var dbContext = dbContextProvider.GetDbContext(controller, serviceProvider);
                return new InMemoryEventBus(dbContext);
            });
            return services;
        }
    }
}
