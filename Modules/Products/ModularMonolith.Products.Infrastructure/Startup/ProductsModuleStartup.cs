using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Products.Application.Commands.AddProduct;
using ModularMonolith.Products.Application.EventBus;
using ModularMonolith.Products.Domain.Interfaces;

namespace ModularMonolith.Products.Infrastructure.Startup
{
    public static class ProductsModuleStartup
    {
        public static IServiceCollection AddProductModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AddProductCommand));
            
            services.AddDbContext<ProductsModuleDbContext>(x =>
            {
                var connectionString = configuration["Modules:ProductsModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductEventBus, ProductsModuleEventBus>();

            return services;
        }
    }
}
