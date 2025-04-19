using Microsoft.AspNetCore.Mvc;
using WebApi.Impl.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [FakeAuthorize]
        [HttpGet("fakeuser")]
        public IActionResult GetUserInfo()
        {
            var userId = HttpContext.Items["UserId"];
            return Ok(new
            {
                message = "data is for logged in users only",
                userId = userId
            });
        }

        [FakeAuthorize]
        [HttpGet("loginuser")]
        public IActionResult GetSecretData()
        {
            return Ok("there is access");
        }
    }
}
