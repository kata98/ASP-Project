using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Implementation;
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
    public class TagController : ControllerBase
    {
        private UseCaseHandler _handler;
        private IAddTagCommand _command;
        public TagController(UseCaseHandler handler, IAddTagCommand command)
        {
            _handler = handler;
            _command = command;
        }


        [HttpPost]
        public IActionResult Post([FromBody] AddTagDto dto)
        {
            _handler.HandleCommand(_command, dto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
