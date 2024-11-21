using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Application.EventBus;
using ModularMonolith.Products.Application.Features.Products.Create;

namespace ModularMonolith.ProductCatalog.Infrastructure.Startup
{
    public static class ProductsModuleStartup
    {
        public static IServiceCollection AddProductModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateProductCommand));

            services.AddDbContext<ProductsModuleDbContext>(x =>
            {
                var connectionString = configuration["Modules:ProductsModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });

            services.AddScoped<IAttributeValidator, AttributeValidator>();
            services.AddScoped<IProductModuleDbContext, ProductsModuleDbContext>();

            services.AddScoped<IProductEventBus, ProductsModuleEventBus>();

            return services;
        }
    }
}