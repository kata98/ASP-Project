using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.Logging
{
    public interface IExceptionLoggers
    {
        void Log(Exception ex);
    }
}
