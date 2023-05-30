using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Domain.Entities
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
    }
}
