using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}
