using Microsoft.AspNetCore.Mvc;

namespace DockerService.Controllers;

[ApiController]
[Route("[controller]")]
public class Service : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        string? returnValue = Environment.GetEnvironmentVariable("returnValue");
        if (returnValue == null) return BadRequest("Missing returnValue!");
        return Ok(returnValue);
    }
}
