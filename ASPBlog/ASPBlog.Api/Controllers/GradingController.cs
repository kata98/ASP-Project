using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
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
    public class GradingController : ControllerBase
    {
        private UseCaseHandler _handler;
        public GradingController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddGradeDto dto, [FromServices]IAddGradeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteGradingCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
