using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.Exceptions
{
    public class ForbiddenExecutionException : Exception
    {
        public ForbiddenExecutionException(string useCase, string user) : base($"User {user} has tried to execute {useCase} without being authorized to do so")
        {

        }
    }
}
