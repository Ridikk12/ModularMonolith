using System;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ModularMonolith.Infrastructure.Logging
{
    public static class LoggerConfiguration
    {
        public static IHostBuilder UseSerilogLogger(this IHostBuilder hostBuilder) => hostBuilder.UseSerilog(
            (context, configuration) =>
           {
               bool.TryParse(context.Configuration["Logger:EnableConsole"], out var enableConsole);
               bool.TryParse(context.Configuration["Logger:EnableFile"], out var enableFile);
               bool.TryParse(context.Configuration["Logger:Seq:Enable"], out var enableSeq);

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

               if (enableSeq)
               {
                   var apiKey = context.Configuration["Logger:Seq:ApiKey"];
                   var seqUrl = context.Configuration["Logger:Seq:URL"];
                   configuration.WriteTo.Seq(seqUrl, apiKey: apiKey);
               }

               configuration.Enrich.FromLogContext();

               var loggingLevelSwitch = new LoggingLevelSwitch { MinimumLevel = logLevel };
               configuration.MinimumLevel.ControlledBy(loggingLevelSwitch);
           });
    }
}

