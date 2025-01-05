namespace Catalog.Application.Dtos;

public class EditTovarDto
{
    /// <summary>
    /// Айди товара
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Имя товара
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Категория товара
    /// </summary>
    public string Category { get; init; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Тип валюты
    /// </summary>
    public int PriceCurrencyType { get; init; }

    /// <summary>
    /// Единица товара
    /// </summary>
    public float Unit { get; init; }

    /// <summary>
    /// Тип единицы товара
    /// </summary>
    public int UnitType { get; init; }
}