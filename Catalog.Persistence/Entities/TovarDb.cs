namespace Catalog.Persistence.Entities;

public class TovarDb
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

    public int CurrrencyType { get; set; }
    
    /// <summary>
    /// Единица товара
    /// </summary>
    public float Unit { get; set; }
    
    public int UnitType { get; set; }
    
}