using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.Queries;
using ASPBlog.Implementation;
using ASPBlog.Implementation.UseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UseCaseHandler _handler;
        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IFindUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateUserRoleDto request, [FromServices] IUpdateUserRole command)
        {
            _handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
