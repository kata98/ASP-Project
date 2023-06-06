using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserController : ControllerBase
    {
        public IActionResult Get([FromServices] IApplicationUser user)
        {
            return Ok(user);
        }
    }
}
