using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DockerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service : ControllerBase
    {
        //        service/
        [HttpGet(Name = "Get")]
        public async Task<ActionResult<string>> Get()
        {  
            string returnValue = Environment.GetEnvironmentVariable("returnValue");
            if (returnValue!=null)
            {
                return Ok(returnValue);
            }
            else
            {
                return BadRequest("dont have a return value!");
            }
        }
    }
}