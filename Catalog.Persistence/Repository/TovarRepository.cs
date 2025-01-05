using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Persistence.Entities;
using Catalog.Persistence.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repository;

public class TovarRepository : ITovarRepository
{
    private readonly ShopContext _context;

    public TovarRepository(ShopContext context)
    {
        _context = context;
    }
    
    public Task AddAsync(Tovar tovar, CancellationToken cancellationToken)
    {
        var tovarDb = tovar.MapToDb();
        return _context.Tovars.AddAsync(tovarDb, cancellationToken).AsTask();
    }

    public async Task<List<Tovar>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tovarDbs = await _context.Tovars.ToListAsync(cancellationToken);
        return tovarDbs.Select(t => t.MapToEntity()).ToList();
    }

    public async Task<Tovar?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var tovarDb = await _context.Tovars.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        return tovarDb?.MapToEntity();
    }

    public async Task Update(Tovar tovar, CancellationToken cancellationToken)
    {
        var tovarDb = await _context.Tovars.FirstOrDefaultAsync(t => t.Id == tovar.Id, cancellationToken);
        tovarDb.Name = tovar.Name;
        tovarDb.Category = tovar.Category;
        tovarDb.Price = tovar.Price.Value;
        tovarDb.CurrrencyType = (int)tovar.Price.CurrencyType;
        tovarDb.Unit = tovar.Unit.Value;
        tovarDb.UnitType = (int)tovar.Unit.Type;
        
        await Task.CompletedTask;
    }
    
    public async Task DeleteAsync(Guid tovarId, CancellationToken cancellationToken)
    {
        var tovarDb = await _context.Tovars.FirstOrDefaultAsync(t => t.Id == tovarId, cancellationToken);
        if (tovarDb != null)
        {
            _context.Tovars.Remove(tovarDb);
        }
    }
}