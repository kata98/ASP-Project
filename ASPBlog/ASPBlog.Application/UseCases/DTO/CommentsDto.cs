using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.DTO
{
    public class AddCommentsDto
    {
        public int PostId { get; set; }
        public string Text { get; set; }
    }
    public class FindPostCommentsDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}
