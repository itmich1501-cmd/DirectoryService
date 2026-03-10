using Microsoft.AspNetCore.Mvc;

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
}