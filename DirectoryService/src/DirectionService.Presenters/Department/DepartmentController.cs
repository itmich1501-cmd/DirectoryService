using DirectionService.Application.Locations.Command;
using DirectionService.Contracts.Locations.Requests;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions;
using Shared.Framework.ResponseExtensions;

namespace DirectionService.Presenters.Department;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Test()
    {
        return Task.FromResult<IActionResult>(Ok("test"));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICommandHandler<Guid, CreateLocationCommand> commandHandler,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(
            request.Name,
            request.Address.Country,
            request.Address.City,
            request.Address.Street,
            request.Address.HouseNumber,
            request.Address.PostalCode,
            request.TimeZone);

        var result = await commandHandler.Handle(command, cancellationToken);

        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }
}