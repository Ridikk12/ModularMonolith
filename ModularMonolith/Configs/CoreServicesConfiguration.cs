using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Contracts;
using ModularMonolith.Infrastructure.Behaviours;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Products.Application.Commands.AddProduct;

namespace ModularMonolith.Configs;

public static class CoreServicesConfiguration
{
    public static void AddApplicationCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ProductCratedIntegrationEvent));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<AddProductValidator>();

        services.AddInMemoryEventBus();
        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();

    }
}