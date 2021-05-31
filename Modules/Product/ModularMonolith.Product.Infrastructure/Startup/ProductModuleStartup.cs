using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Product.Application.Commands;
using ModularMonolith.Product.Application.EventBus;
using ModularMonolith.Product.Domain.Interfaces;

namespace ModularMonolith.Product.Infrastructure.Startup
{
    public static class ProductModuleStartup
    {
        public static IServiceCollection AddProductModule(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddProductCommand));
            services.AddDbContext<ProductDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductEventBus, ProductEventBus>();

            return services;
        }
    }
}
