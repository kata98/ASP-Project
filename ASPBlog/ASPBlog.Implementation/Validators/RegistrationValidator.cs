using FluentValidation;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPBlog.Implementation.Validators
{
    public class RegistrationValidator : AbstractValidator<RegisterDto>
    {
        public RegistrationValidator(ASPBlogDbContext _context)
        {
            var NameRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";
            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(NameRegex).WithMessage("Not meeting the rules for name.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches(NameRegex).WithMessage("Not meeting the rules for last name.");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Minimum character length is 3.")
                .MaximumLength(30).WithMessage("Maximum character length is 30.")
                .Matches("^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$").WithMessage("Not meeting rules for username.")
                .Must(x => !_context.Users.Any(y => y.Username == x)).WithMessage("This username {PropertyValue} is already in use.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Not meeting the rules for email.")
                .Must(x => !_context.Users.Any(u => u.Email == x)).WithMessage("This email {PropertyValue} is already in use.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!#%*?&])[A-Za-z\d@$#!%*?&]{8,}$").WithMessage("Password must have minimum 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.");
        }
    }
}
