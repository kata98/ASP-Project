using ASPBlog.Application.UseCases.DTO;

namespace ASPBlog.Application.UseCases.Queries
{
    public interface IFindPostsQuery : IQuery<int, FindPostDto>
    {
    }
}
