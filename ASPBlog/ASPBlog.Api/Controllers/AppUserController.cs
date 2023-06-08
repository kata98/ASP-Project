using ASPBlog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    [ApiExplorerSettings(IgnoreApi = true)]
    public class AppUserController : ControllerBase
    {
        public IActionResult Get([FromServices] IApplicationUser user)
        {
            return Ok(user);
        }
    }
}
