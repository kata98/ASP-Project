using Microsoft.AspNetCore.Http;
using ASPBlog.Application.UseCases.DTO;

namespace ASPBlog.Api.DTO
{
    public class AddPostApiDto : AddPostDto
    {
        public IFormFile Image { get; set; }
    }
    public class RegisterApiDto : RegisterDto
    {
        public IFormFile ImagePath { get; set; }
    }
}
