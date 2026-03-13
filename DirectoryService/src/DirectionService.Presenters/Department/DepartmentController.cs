using DirectionService.Application.Locations.Command;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions;

namespace DirectionService.Presenters.Department;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok("test");
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICommandHandler<Guid, CreateLocationCommand> commandHandler,
        CancellationToken cancellationToken)
    {
        
    }
}