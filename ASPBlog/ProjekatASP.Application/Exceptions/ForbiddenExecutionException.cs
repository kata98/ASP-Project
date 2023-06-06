using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.Exceptions
{
    public class ForbiddenExecutionException : Exception
    {
        public ForbiddenExecutionException(string useCase, string user) : base($"User {user} has tried to execute {useCase} without being authorized to do so")
        {

        }
    }
}
