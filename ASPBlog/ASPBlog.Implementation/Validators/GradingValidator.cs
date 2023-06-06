using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.Validators
{
    public class GradingValidator : AbstractValidator<AddGradeDto>
    {
        private readonly IApplicationUser _user;
        public GradingValidator(ASPBlogDbContext _context, IApplicationUser user)
        {
            _user = user;
            var ValueRegex = @"^[1-5]$";
            RuleFor(x => x.Grade).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Grade value can't be empty")
                .InclusiveBetween(1, 5).WithMessage("Grade must be number between 1 and 5");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User Id is required")
                .Must(x => _context.Posts.Any(y => y.Id == x))
                .WithMessage("Post with Id {PropertyValue} does not exist.");

            RuleFor(m => new { _user.Id, m.PostId })
                .Must(x =>
                {
                    if (_context.Gradings.Any(y => y.UserId == _user.Id) && _context.Gradings.Any(y => y.PostId == x.PostId))
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("This user has already given a grade for this post");
        }
    }
}
