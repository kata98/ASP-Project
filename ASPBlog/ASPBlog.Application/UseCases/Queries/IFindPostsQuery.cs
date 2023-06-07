using ASPBlog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.Queries
{
    public interface IFindPostsQuery : IQuery<int, FindPostDto>
    {
    }
}
