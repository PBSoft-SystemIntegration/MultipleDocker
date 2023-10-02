using Microsoft.AspNetCore.Mvc;

namespace MultipleDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderService : ControllerBase
    {
        [HttpGet(Name = "GetOrder")]
        public async Task<ActionResult<string>> Get()
        {
            HttpClient client = new HttpClient();
            string urlAdress = Environment.GetEnvironmentVariable("urlAdress");
            if (urlAdress == null)
            {
                return BadRequest("Missing urlAdress!");
            }
            var resp = await client.GetAsync("http://"+urlAdress);
            if (!resp.IsSuccessStatusCode)
            {
                return BadRequest($"cant connect {urlAdress}");
            }
            else
            {
                var ans = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(ans);
            }
            //keep asking other services...
            return Ok("all the things did the thing");
        }
    }
}