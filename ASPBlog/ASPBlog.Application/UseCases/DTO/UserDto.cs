using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.Application.UseCases.DTO
{
    public class FindUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? Image { get; set; }
        public IEnumerable<UsersCommentDto> Comments { get; set; }
        public IEnumerable<UsersGradingDto> Gradings { get; set; }
    }
    public class FindAdminModeratorDto : FindUserDto
    {
        public IEnumerable<FindCategoryUserPostDto> Posts { get; set; }
    }
    public class UsersCommentDto
    {
        public string PostTitle { get; set; }
        public string Text { get; set; }
    }
    public class UsersGradingDto
    {
        public string PostTitle { get; set; }
        public int Grade { get; set; }
    }
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
    }
}
