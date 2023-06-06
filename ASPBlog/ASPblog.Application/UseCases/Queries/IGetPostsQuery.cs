using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases.Queries
{
    public interface IGetPostsQuery : IQuery<BasePagedSearch, PagedResponse<PostsDto>>
    {
    }
}
