using ASPBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(ASPBlogDbContext context)
        {
            Context = context;
        }

        protected ASPBlogDbContext Context { get; }
    }
}
