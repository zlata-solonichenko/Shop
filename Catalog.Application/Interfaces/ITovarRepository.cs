using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces;

public interface ITovarRepository
{
    /// <summary>
    /// Метод находит товар по айди
    /// </summary>
    /// <param name="id">айди товара</param>
    Task<Tovar?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод возвращает все товары
    /// </summary>
    Task<List<Tovar>> GetAllAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод добавления товара в каталог
    /// </summary>
    /// <param name="tovar">объект товара</param>
    Task AddAsync(Tovar tovar, CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод редактирования товара из каталога
    /// </summary>
    Task Update(Tovar tovar, CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод удаления товара из каталога
    /// </summary>
    Task DeleteAsync(Guid tovarId, CancellationToken cancellationToken);
}