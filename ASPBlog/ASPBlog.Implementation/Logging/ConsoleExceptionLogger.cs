using ASPBlog.Application.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.ExceptionHandling;

namespace ProjekatASP.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Occurred at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
