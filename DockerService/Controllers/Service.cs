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
        Console.WriteLine("Modtog GET /Service");
        if (returnValue == null)
        {
            Console.WriteLine("Fejl: returnValue mangler.");
            return BadRequest("Missing returnValue!");
        }
        Console.WriteLine($"Sender svar: {returnValue}");
        return Ok(returnValue);
    }
}
