using System;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddDbContext<AppDbContext>(options=>{
            options.UseMySql(configuration.GetConnectionString("Ecommerce"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("Ecommerce")));

        });
        return services;
    }
}
