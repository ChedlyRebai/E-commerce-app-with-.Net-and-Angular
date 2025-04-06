using System;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection infrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // services.AddScoped<ICategoryReppository, CategoryRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<IPhotoRepository, PhotoRepository>();


        services.AddScoped<IUnitOfWork ,UnitOfWork>();
        services.AddSingleton<IImageMangeService, ImageMangeService>();
        //An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Core.Interfaces.IUnitOfWork Lifetime: Scoped ImplementationType: Infrastructure.Repositories.UnitOfWork': Unable to resolve service for type 'Microsoft.Extensions.FileProviders.IFileProvider' while attempting to activate 'Infrastructure.Repositories.Service.ImageMangeService'.) (Error while validating the service descriptor 'ServiceType: Core.Services.IImageMangeService Lifetime: Singleton ImplementationType: Infrastructure.Repositories.Service.ImageMangeService': Unable to resolve service for type 'Microsoft.Extensions.FileProviders.IFileProvider' while attempting to activate 'Infrastructure.Repositories.Service.ImageMangeService'.)
        services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        services.AddDbContext<AppDbContext>(options=>{
            options.UseMySql(
            configuration.GetConnectionString("Ecommerce"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("Ecommerce")));
        
        });
        return services;
    }
}
