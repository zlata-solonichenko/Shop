namespace Catalog.Api.Dtos;

public class EditTovarRequest
{
    /// <summary>
    /// Айди товара
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Категория товара
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Тип валюты
    /// </summary>
    public int PriceCurrencyType { get; set; }

    /// <summary>
    /// Единица товара
    /// </summary>
    public float Unit { get; set; }

    /// <summary>
    /// Тип единицы товара
    /// </summary>
    public int UnitType { get; set; }
}