using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;

namespace ModularMonolith.Infrastructure.Exceptions
{
    public static class LoggerConfiguration
    {
        public static IHostBuilder UseLogger(this IHostBuilder hostBuilder) => hostBuilder.UseSerilog(
            (context, configuration) =>
           {
               bool.TryParse(context.Configuration["Logger:EnableConsole"], out var enableConsole);
               bool.TryParse(context.Configuration["Logger:EnableFile"], out var enableFile);
               Enum.TryParse<LogEventLevel>(context.Configuration["Logger:LogLevel"], out var logLevel);

               if (enableFile)
               {
                   var filePath = context.Configuration["Logger:FilePath"];
                   if (string.IsNullOrEmpty(filePath))
                       throw new ArgumentException("Logger file path has to be set.");

                   configuration.WriteTo.File(filePath, rollingInterval: RollingInterval.Day);
               }

               if (enableConsole)
                   configuration.WriteTo.Console();

               configuration.Enrich.FromLogContext();

               var loggingLevelSwitch = new LoggingLevelSwitch { MinimumLevel = logLevel };
               configuration.MinimumLevel.ControlledBy(loggingLevelSwitch);
           });
    }
}

