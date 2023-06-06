using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.Exceptions
{
    public class UseCaseConflictException : Exception
    {
        public UseCaseConflictException(string message) : base(message)
        {

        }
    }
}
