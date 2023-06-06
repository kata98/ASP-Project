using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;

namespace ASPBlog.Implementation.Validators
{
    public class TagValidator : AbstractValidator<AddTagDto>
    {
        public TagValidator(ASPBlogDbContext context)
        {
            var TagRegex = "^[A-Z][A-z]*$";
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Tag name is required")
                .Matches(TagRegex.Trim()).WithMessage("Tag must be one word with a Capital letter and without any special signs or numbers");
        }
    }
}
