using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Domain.Entities
{
    public class PostImage
    {
        public int PostId { get; set; }
        public int ImgId { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual Image Image { get; set; }
    }
}
