using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? ImgId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Image Image { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Grading> Gradings { get; set; } = new List<Grading>();
        public virtual ICollection<UserUseCase> UseCases { get; set; }


    }
}
