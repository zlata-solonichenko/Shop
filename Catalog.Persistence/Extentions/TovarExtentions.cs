using Catalog.Domain.Entities;
using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;
using Catalog.Persistence.Entities;

namespace Catalog.Persistence.Extentions;

/// <summary>
/// Сущность расширений товара
/// </summary>
public static class TovarExtentions
{
    public static TovarDb MapToDb(this Tovar tovar)
    {
        if (tovar == null)
        {
            throw new ArgumentException("Товар не может быть null");
        }

        var tovarDb = new TovarDb
        {
            Id = tovar.Id,
            Name = tovar.Name,
            Category = tovar.Category,
            Price = tovar.Price.Value,
            CurrrencyType = (int)tovar.Price.CurrencyType,
            Unit = tovar.Unit.Value,
            UnitType = (int)tovar.Unit.Type,
        };

        return tovarDb;
    }

    public static Tovar MapToEntity(this TovarDb tovarDb)
    {
        if (tovarDb == null)
        {
            throw new ArgumentException("Товар не может быть null");
        }

        var tovar = new Tovar(tovarDb.Id, tovarDb.Name, tovarDb.Category, 
            new Price
            {
                Value = tovarDb.Price,
                CurrencyType = (CurrencyType)tovarDb.CurrrencyType
            },
            new Unit
            {
                Value = tovarDb.Unit,
                Type = (UnitType)tovarDb.UnitType
            });
        return tovar;
    }
}