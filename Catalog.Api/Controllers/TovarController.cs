using Catalog.Api.Dtos;
using Catalog.Application.Dtos;
using Catalog.Application.Interfaces;
using Catalog.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[Route("api/tovar")]
[ApiController]
public class TovarController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] ITovarRepository repository,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("new")]
    public async Task<IActionResult> CreateTovarAsync(
        [FromBody] CreateTovarDto request, //CreateTovarRequest ??
        [FromServices] ICreateTovarUseCase useCase, 
        CancellationToken cancellationToken)
    {
        var newTowar = await useCase.ExecuteAsync(request, cancellationToken);

        return Ok(new {id = newTowar});
    }

    [HttpPut("update")]
    public async Task<IActionResult> EditTovarAsync(
        [FromBody] EditTovarRequest request,
        [FromServices] IEditTovarUseCase useCase,
        CancellationToken cancellationToken
        )
    {
        var dto = new EditTovarDto
        {
            Id = request.Id,
            Name = request.Name,
            Category = request.Category,
            Price = request.Price,
            PriceCurrencyType = request.PriceCurrencyType,
            Unit = request.Unit,
            UnitType = request.UnitType
        };

        await useCase.ExecuteAsync(dto, cancellationToken);

        return Ok();
    }
    
    //Новое доделала
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] ITovarRepository repository,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    
    //пишет "успешно", но из бд не удаляет
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteTovarAsync(
        [FromRoute] Guid id,
        [FromServices] IDeleteTovarUseCase useCase,
        CancellationToken cancellationToken
    )
    {
        await useCase.ExecuteAsync(id, cancellationToken);
        return Ok();
    }
}