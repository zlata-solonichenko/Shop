using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopContext _shopContext;

    public UnitOfWork(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _shopContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Метод сохраняет изменения, сделанные в контексте, в базу данных
    /// </summary>
    public Task SaveChangesAsync()
    {
        return _shopContext.SaveChangesAsync();
    }

    /// <summary>
    /// Метод обновляет базу данных до последней версии миграций
    /// </summary>
    public Task MigrateDatabaseAsync()
    {
        return _shopContext.Database.MigrateAsync();
    }

    /// <summary>
    /// Метод ссвобождает ресурсы, используемые _shopContext, предотвращая утечки памяти
    /// </summary>
    public void DisposeTask()
    {
        _shopContext.Dispose();
    }
}