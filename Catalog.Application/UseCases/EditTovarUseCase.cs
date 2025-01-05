using Catalog.Application.Dtos;
using Catalog.Application.Interfaces;
using Catalog.Application.UseCases.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.UseCases;

public class EditTovarUseCase :IEditTovarUseCase
{
    private readonly ITovarRepository _tovarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditTovarUseCase(ITovarRepository tovarRepository, IUnitOfWork unitOfWork)
    {
        _tovarRepository = tovarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(EditTovarDto dto, CancellationToken cancellationToken)
    {
        var tovar = await _tovarRepository.GetByIdAsync(dto.Id, cancellationToken);
        tovar.SetName(dto.Name);
        tovar.SetCategory(dto.Category);
        
        var price = new Price{CurrencyType = (CurrencyType)dto.PriceCurrencyType, Value = dto.Price};
        var unit = new Unit {Value = dto.Unit, Type = (UnitType)dto.UnitType};
        tovar.SetPrice(price);
        tovar.SetUnit(unit);
        
        await _tovarRepository.Update(tovar, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}