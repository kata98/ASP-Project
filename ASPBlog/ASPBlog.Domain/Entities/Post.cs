using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
        public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
        public virtual ICollection<Grading> Gradings { get; set; } = new List<Grading>();
    }
}
