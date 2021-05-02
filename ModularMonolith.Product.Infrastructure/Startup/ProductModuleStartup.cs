using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Product.Application.Commands;
using ModularMonolith.Product.Domain;

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
            return services;
        }
    }
}
