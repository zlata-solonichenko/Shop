namespace Catalog.Domain.Enums;

/// <summary>
/// Сущность типов для едениц товара
/// </summary>
public enum UnitType
{
    /// <summary>
    /// Неизвестно
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// Штучно
    /// </summary>
    Piece = 1, 
    
    /// <summary>
    /// Кг
    /// </summary>
    Kilogram = 2,
    
    /// <summary>
    /// Литр
    /// </summary>
    Litre = 3,
}