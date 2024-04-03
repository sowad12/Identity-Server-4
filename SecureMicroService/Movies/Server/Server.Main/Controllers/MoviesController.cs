using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Main.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet("hello")]
        public async Task<IActionResult> CheckSenderDomain(string domainName)
        {
            //var result = await _clubManager.CheckSenderDomainAsync(domainName).AsSuccess();
            return Ok();
        }
    }
}
