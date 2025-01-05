using System.Text;
using Catalog.Application.Interfaces;
using Catalog.Application.UseCases.Interfaces;
using Catalog.Domain.Entities;

namespace Catalog.Application.UseCases;

public class DeleteTovarUseCase : IDeleteTovarUseCase
{
    private readonly ITovarRepository _tovarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTovarUseCase(ITovarRepository tovarRepository, IUnitOfWork unitOfWork)
    {
        _tovarRepository = tovarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(Guid tovarId, CancellationToken cancellationToken)
    {
        var tovar = await _tovarRepository.GetByIdAsync(tovarId, cancellationToken);
        if (tovar != null)
        {
            await _tovarRepository.DeleteAsync(tovarId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}