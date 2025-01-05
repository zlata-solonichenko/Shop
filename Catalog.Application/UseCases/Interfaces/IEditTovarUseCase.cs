using Catalog.Application.Dtos;

namespace Catalog.Application.UseCases.Interfaces;

public interface IEditTovarUseCase
{
    Task ExecuteAsync(EditTovarDto dto, CancellationToken cancellationToken);
}