using Catalog.Domain.Enums;

namespace Catalog.Domain.ValueObjects;

/// <summary>
/// Сущность цены товара
/// </summary>
public class Price
{
    /// <summary>
    /// Значение цены
    /// </summary>
    public Decimal Value { get; set; }
    
    /// <summary>
    /// Тип валюты
    /// </summary>
    public CurrencyType CurrencyType { get; set; }
}