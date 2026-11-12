using Microsoft.AspNetCore.Mvc;

namespace OfficeOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return Ok(value);
        }
    }
}
