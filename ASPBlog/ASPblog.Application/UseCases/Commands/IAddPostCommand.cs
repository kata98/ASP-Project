using ASPBlog.Application.UseCases.DTO;

namespace ASPBlog.Application.UseCases.Commands
{
    public interface IAddPostCommand : ICommand<AddPostDto>
    {
    }
}
