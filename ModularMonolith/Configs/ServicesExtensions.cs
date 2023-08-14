using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.History.Infrastructure.Startup;
using ModularMonolith.Outbox;
using ModularMonolith.Outbox.WorkerProcess;
using ModularMonolith.Products.Infrastructure.Startup;
using ModularMonolith.User.Infrastructure.Startup;

namespace ModularMonolith.Configs;

public static class ServicesExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddRouting(x => x.LowercaseUrls = true);

        services.AddProductModule(configuration)
            .AddHistoryModule(configuration)
            .AddOutBoxModule(configuration)
            .AddUserModule(configuration);

        services.AddApplicationCoreServices();
        services.AddApplicationSwagger();

        services.AddHostedService<OutBoxWorker>();
    }
}