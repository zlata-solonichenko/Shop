using Catalog.Application.Dtos;

namespace Catalog.Application.UseCases.Interfaces;

public interface ICreateTovarUseCase
{
    Task<Guid> ExecuteAsync(CreateTovarDto dto, CancellationToken cancellationToken);
}