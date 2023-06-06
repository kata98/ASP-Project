using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using System.Linq;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.Validators
{
    public class CommentsValidator : AbstractValidator<AddCommentsDto>
    {
        private readonly IApplicationUser _user;
        public CommentsValidator(ASPBlogDbContext _context, IApplicationUser user)
        {
            _user = user;

            RuleFor(x => x.Text).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Comment can't be empty");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post Id is required")
                .Must(x => _context.Posts.Any(y => y.Id == x))
                .WithMessage("Post with Id {PropertyValue} does not exist.");

            RuleFor(m => new { _user.Id, m.PostId })
                .Must(x =>
                {
                    if (_context.Comments.Any(y => y.UserId == _user.Id) && _context.Comments.Any(y => y.PostId == x.PostId))
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("This user has already commented on this post");
        }
    }
}
