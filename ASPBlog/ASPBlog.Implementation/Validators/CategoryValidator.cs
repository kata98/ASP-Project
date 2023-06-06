using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<AddCategoryDto>
    {
        public CategoryValidator(ASPBlogDbContext _context)
        {
            var CatRegex = "^[A-Z][a-z]*$";
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category name is required")
                .Matches(CatRegex.Trim()).WithMessage("Category must be one word with a Capital letter and without any special signs or numbers");

            
        }
    }
}
