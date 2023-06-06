using ASPBlog.Domain;
using System.Collections.Generic;

namespace ASPBlog.Api.Core
{
    public class JwtUser : IAppUser
    {
        public string Identity { get; set; }
        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }
        public int RoleId { get; set; }
    }

    public class AnonimousUser : IAppUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 4, 5 };

        public string Email => "anonimous@asp-api.com";

        public int RoleId => 0;

    }
}
