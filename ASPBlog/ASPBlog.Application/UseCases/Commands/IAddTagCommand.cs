﻿using ASPBlog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.Commands
{
    public interface IAddTagCommand : ICommand<AddTagDto>
    {
    }
}
