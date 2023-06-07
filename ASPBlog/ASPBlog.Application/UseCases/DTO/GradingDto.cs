using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.DTO
{
    public class AddGradeDto
    {
        public int PostId { get; set; }
        public int Grade { get; set; }
    }
}
