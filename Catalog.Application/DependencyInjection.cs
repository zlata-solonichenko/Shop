using Catalog.Application.UseCases;
using Catalog.Application.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catalog.Application;

public static class DependencyInjecton
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new ArgumentException("Отсутствует строка подключения.");
        
        services.AddScoped<ICreateTovarUseCase, CreateTovarUseCase>();
        services.AddScoped<IDeleteTovarUseCase, DeleteTovarUseCase>();
        services.AddScoped<IEditTovarUseCase, EditTovarUseCase>();
        return services;
    }
}