using ASPBlog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases.Commands
{
    public interface IAddCommentCommand : ICommand<AddCommentsDto>
    {
    }
}
