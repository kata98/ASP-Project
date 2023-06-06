using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases
{
    public interface IQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest search);
    }
}
