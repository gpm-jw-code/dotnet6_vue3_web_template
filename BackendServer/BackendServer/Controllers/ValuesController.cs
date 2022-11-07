using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("SystemTIme")]
        public async Task<IActionResult> GetDatetime()
        {
            return Ok(DateTime.Now.ToShortDateString());
        }
    }
}
