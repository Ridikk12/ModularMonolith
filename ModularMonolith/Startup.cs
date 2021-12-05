using System;
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
using ModularMonolith.Infrastructure;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.Outbox;
using ModularMonolith.Outbox.WorkerProcess;
using ModularMonolith.Product.Infrastructure.Startup;
using ModularMonolith.User.Contracts;
using ModularMonolith.User.Infrastructure.Startup;
using Refit;

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
            services.AddMediatR(typeof(ProductCratedIntegrationEvent));

            services.AddProductModule();
            services.AddHistoryModule();
            services.AddHttpContextAccessor();
            services.AddOutBoxModule();
            services.AddInMemoryEventBus();

            services.AddScoped<IUserContext, UserContext>();

            services.AddUserModule(Configuration);

            services.AddHostedService<OutBoxWorker>();

            services.AddSwaggerGen(c => {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
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
