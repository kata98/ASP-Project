using ASPBlog.Application.Emails;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Implementation.Validators;
using System.Collections.Generic;
using ASPBlog.Domain.Entities;
using FluentValidation;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class RegisterUserCommand : EfUseCase, IRegistrationCommand
    {
        private readonly RegistrationValidator _validator;
        private readonly IEmailSender _sender;
        public RegisterUserCommand(ASPBlogDbContext context, RegistrationValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 5;

        public string Name => "User registration";

        public string Description => "User registration used by Anonymous users";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                RoleId = 3 
            };

            if (!string.IsNullOrEmpty(request.ImgPathName))
            {
                var newImage = new Image
                {
                    Path = request.ImgPathName
                };
                user.Image = newImage;
            }
            Context.Users.Add(user);

            var useCases = new List<UserUseCase>
            {
                new UserUseCase  { User = user, UseCaseId = 3 },
                new UserUseCase  { User = user, UseCaseId = 4 }
            };

            Context.UserUseCases.AddRange(useCases);

            Context.SaveChanges();

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account...."
            });
        }
    }
}
