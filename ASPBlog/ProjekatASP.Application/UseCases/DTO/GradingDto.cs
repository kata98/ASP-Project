using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases.DTO
{
    public class AddGradeDto
    {
        public int PostId { get; set; }
        public int Grade { get; set; }
    }
}
