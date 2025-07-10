using System;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;


public static class InfrastructureRegistration
{
    public static IServiceCollection infrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // services.AddScoped<ICategoryReppository, CategoryRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<IPhotoRepository, PhotoRepository>();

        services.AddSingleton<IConnectionMultiplexer>(i =>
        {
            var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
            return ConnectionMultiplexer.Connect(config);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddSingleton<IImageMangeService, ImageMangeService>();
        services.AddScoped<IGenerateToken, GenrateToken>();

        // Register ASP.NET Core Identity with custom user and role types.
        // Use Entity Framework Core for persistence and add default token providers.
     
        //An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Core.Interfaces.IUnitOfWork Lifetime: Scoped ImplementationType: Infrastructure.Repositories.UnitOfWork': Unable to resolve service for type 'Microsoft.Extensions.FileProviders.IFileProvider' while attempting to activate 'Infrastructure.Repositories.Service.ImageMangeService'.) (Error while validating the service descriptor 'ServiceType: Core.Services.IImageMangeService Lifetime: Singleton ImplementationType: Infrastructure.Repositories.Service.ImageMangeService': Unable to resolve service for type 'Microsoft.Extensions.FileProviders.IFileProvider' while attempting to activate 'Infrastructure.Repositories.Service.ImageMangeService'.)
        services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
         // Identity configuration
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "token";
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            // JWT Bearer authentication
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Token:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];
                            return Task.CompletedTask;
                        }
                    };
                });
        return services;
    }
}
