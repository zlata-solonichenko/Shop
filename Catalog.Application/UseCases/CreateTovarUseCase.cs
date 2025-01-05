using Catalog.Application.Dtos;
using Catalog.Application.Interfaces;
using Catalog.Application.UseCases.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Enums;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.UseCases;

public class CreateTovarUseCase : ICreateTovarUseCase
{
    private readonly ITovarRepository _tovarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTovarUseCase(ITovarRepository tovarRepository,IUnitOfWork unitOfWork)
    {
        _tovarRepository = tovarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> ExecuteAsync(CreateTovarDto dto, CancellationToken cancellationToken) //CreateTovarDto dto
    {
        var price = new Price{CurrencyType = (CurrencyType)dto.PriceCurrencyType, Value = dto.Price};
        var unit = new Unit {Value = dto.Unit, Type = (UnitType)dto.UnitType};
        
        var newTovar = new Tovar(dto.Name, dto.Category, price, unit);
        await _tovarRepository.AddAsync(newTovar, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return newTovar.Id;
    }
}