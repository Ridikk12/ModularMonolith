using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ModularMonolith.User.Application;
using ModularMonolith.User.Application.Commands.Register;
using ModularMonolith.User.Application.Entities;
using ModularMonolith.User.Application.Interfaces;
using ModularMonolith.User.Application.Queries.GetUserDetails;
using ModularMonolith.User.Contracts;
using ModularMonolith.User.Infrastructure.Services;
using Refit;

namespace ModularMonolith.User.Infrastructure.Startup
{
    public static class UsersModuleStartup
    {
        public static IServiceCollection AddUserModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(RegisterUserCommand));
            
            services.AddDbContext<UsersDbContext>(x =>
            {
                var connectionString = configuration["Modules:UsersModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });
            services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UsersDbContext>();

            services
                .AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c =>
                {
                    var userModuleUrl = configuration["Modules:UsersModule:Url"];
                    c.BaseAddress = new Uri(userModuleUrl);
                });

            services.AddScoped<IUserService, GetUserDetailsQueryHandler>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // AppUser settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);
                var issuer = configuration["Jwt:Issuer"];
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudiences = new List<string>() { issuer },
                    ValidateAudience = true,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });


            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}