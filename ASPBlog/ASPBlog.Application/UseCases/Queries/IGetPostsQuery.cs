using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.Queries
{
    public interface IGetPostsQuery : IQuery<BasePagedSearch, PagedResponse<PostsDto>>
    {
    }
}
