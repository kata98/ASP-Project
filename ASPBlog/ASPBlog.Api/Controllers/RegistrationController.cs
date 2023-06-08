using ASPBlog.Api.DTO;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IRegistrationCommand _command;

        public RegistrationController(UseCaseHandler handler, IRegistrationCommand command)
        {
            _handler = handler;
            _command = command;
        }

        [HttpPost]
        public IActionResult Post([FromForm] RegisterApiDto dto)
        {
            if (dto.ImagePath != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.ImagePath.FileName);

                if (!SupportedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Invalid file extension");
                }

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.ImagePath.CopyTo(fileStream);
                }

                dto.ImgPathName = newFileName;
            }
            _handler.HandleCommand(_command, dto);
            return StatusCode(201);
        }
        private IEnumerable<string> SupportedExtensions =>
            new List<string> { ".png", ".jpeg", ".jpg" };
    }
}
