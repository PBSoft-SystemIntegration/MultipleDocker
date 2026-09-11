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
            using HttpClient client = new HttpClient();
            string? urlAdress = Environment.GetEnvironmentVariable("urlsForExternal");
            if (urlAdress == null) return BadRequest("Missing urlsForExternal!");
            List<string> urls = urlAdress.Split(";").ToList();
            foreach (string url in urls)
            {
                using var resp = await client.GetAsync("http://" + url);
                if (!resp.IsSuccessStatusCode)
                {

                    var bAns = await resp.Content.ReadAsStringAsync();
                    return BadRequest($"Error : {bAns} while connecting to: {url}");
                }
                else
                {
                    var ans = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine(ans);
                }
            }
            //keep asking other services...
            return Ok("all the things did the thing");
        }
    }
}