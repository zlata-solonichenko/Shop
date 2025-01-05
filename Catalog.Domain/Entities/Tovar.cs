using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

/// <summary>
/// Сущность товара
/// </summary>
public class Tovar
{
    /// <summary>
    /// Максимальная длина для имени товара
    /// </summary>
    private const byte MAX_NAME_LENGTH = 60;

    /// <summary>
    /// Максимальная длина для категории товара
    /// </summary>
    private const byte MAX_CATEGORY_LENGTH = 30;

    /// <summary>
    /// Айди товара
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Имя товара
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Категория товара
    /// </summary>
    public string Category { get; private set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public Price Price { get; private set; }

    /// <summary>
    /// Единица товара
    /// </summary>
    public Unit Unit { get; private set; }

    /// <summary>
    /// Конструктор для БД
    /// </summary>
    /// <param name="id">айди товара</param>
    /// <param name="name">имя товара</param>
    /// <param name="category">категория товара</param>
    /// <param name="price">цена товара</param>
    /// <param name="unit">единица товара</param>
    public Tovar(Guid id, string name, string category, Price price, Unit unit)
    {
        Id = id;
        Name = ValidateName(name);
        Category = ValidateCategory(category);
        Price = ValidatePrice(price);
        Unit = ValidateUnit(unit);
    }

    /// <summary>
    /// Конструктор, создающий айди автоматически
    /// </summary>
    /// <param name="name">имя товара</param>
    /// <param name="category">категория товара</param>
    /// <param name="price">цена товара</param>
    /// <param name="unit">единица товара</param>
    public Tovar(string name, string category, Price price, Unit unit) : this(Guid.NewGuid(), name, category, price,
        unit)
    {
    }
    private string ValidateName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name) && name.Length <= MAX_NAME_LENGTH)
        {
            return name;
        }

        throw new ArgumentException("Имя товара пустое или больше максимальной длины!");
    }

    private string ValidateCategory(string category)
    {
        if (!string.IsNullOrWhiteSpace(category) && category.Length <= MAX_CATEGORY_LENGTH)
        {
            return category;
        }

        throw new ArgumentException("Категория товара пустая или больше максимальной длины!");
    }

    private Price ValidatePrice(Price price)
    {
        if (price == null || price.Value < 0 || price.CurrencyType == CurrencyType.Unknown)
        {
            throw new ArgumentException("Невалидное значение для цены товара!");
        }

        return price;
    }

    private Unit ValidateUnit(Unit unit)
    {
        if (unit == null || unit.Value < 0 || unit.Type == UnitType.Unknown)
        {
            throw new ArgumentException("Невалидное значение единицы товара!");
        }
        return unit;
    }
    public void SetName(string name) => Name = ValidateName(name);
    
    public void SetCategory(string category) => Category = ValidateCategory(category);

    public void SetPrice(Price price) => Price = ValidatePrice(price);

    public void SetUnit(Unit unit) => Unit = ValidateUnit(unit);
}