namespace Catalog.Application.UseCases.Interfaces;

public interface IDeleteTovarUseCase
{
    Task ExecuteAsync(Guid tovatId, CancellationToken cancellationToken);
}