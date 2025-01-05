using Catalog.Domain.Enums;

namespace Catalog.Domain.ValueObjects;

public class Unit
{
    /// <summary>
    /// Значение единицы товара
    /// </summary>
    public float Value { get; set; }
    
    /// <summary>
    /// Тип единицы товара
    /// </summary>
    public UnitType Type { get; set; }
}