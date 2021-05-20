using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ModularMonolith.Outbox.WorkerProcess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<OutBoxWorker>();
                });
    }
}
