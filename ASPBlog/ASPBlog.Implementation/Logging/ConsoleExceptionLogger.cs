using ASPBlog.Application.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProjekatASP.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLoggers
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Occurred at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
