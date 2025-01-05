using Catalog.Application.Interfaces;
using Catalog.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new ArgumentException("Отсутствует строка подключения.");
        
        // Добавление DbContext
        services.AddDbContext<ShopContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ITovarRepository, TovarRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}