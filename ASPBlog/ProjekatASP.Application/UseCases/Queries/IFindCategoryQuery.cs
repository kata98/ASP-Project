﻿using ASPBlog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases.Queries
{
    public interface IFindCategoryQuery : IQuery<int, CategoryDto>
    {
    }
}
