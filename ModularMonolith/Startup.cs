using System;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ModularMonolith.Configs;
using ModularMonolith.Contracts;
using ModularMonolith.History.Infrastructure.Startup;
using ModularMonolith.Infrastructure.Behaviours;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox;
using ModularMonolith.Outbox.WorkerProcess;
using ModularMonolith.Products.Application.Commands.AddProduct;
using ModularMonolith.Products.Infrastructure.Startup;
using ModularMonolith.User.Infrastructure.Startup;

namespace ModularMonolith
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(x => x.LowercaseUrls = true);

            services.AddProductModule(Configuration)
                .AddHistoryModule(Configuration)
                .AddOutBoxModule(Configuration)
                .AddUserModule(Configuration);
            
            services.AddApplicationCoreServices();
            services.AddApplicationSwagger();
            
            services.AddHostedService<OutBoxWorker>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Modular Monolith API");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionLoggingMiddleware>();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}