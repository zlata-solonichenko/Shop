using Catalog.Application.UseCases;
using Catalog.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateTovarUseCase, CreateTovarUseCase>();
        services.AddScoped<IDeleteTovarUseCase, DeleteTovarUseCase>();
        services.AddScoped<IEditTovarUseCase, EditTovarUseCase>();
        return services;
    }
}