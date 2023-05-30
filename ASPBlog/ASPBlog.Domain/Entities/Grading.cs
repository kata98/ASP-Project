using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Domain.Entities
{
    public class Grading : Entity
    {
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public int Grade { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
