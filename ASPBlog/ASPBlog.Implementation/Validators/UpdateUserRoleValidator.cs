using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using System.Linq;

namespace ASPBlog.Implementation.Validators
{
    public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleDto>
    {
        public UpdateUserRoleValidator(ASPBlogDbContext context)
        {
            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                .WithMessage("User with provided ID doesn't exist");
        }
    }
}
