using FluentValidation;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Implementation.Validators;
using System;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class AddGradingCommand : EfUseCase, IAddGradeCommand
    {
        private readonly GradeValidator _validator;
        private readonly IApplicationUser _user;
        public AddGradingCommand(ASPBlogDbContext context, GradeValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 3;

        public string Name => "Add grade command";

        public string Description => "Adding grade used by all users in system";

        public void Execute(AddGradeDto request)
        {
            _validator.ValidateAndThrow(request);

            var grade = new Grading
            {
                UserId = _user.Id,
                PostId = request.PostId,
                Grade = request.Grade
            };

            Context.Gradings.Add(grade);
            Context.SaveChanges();
        }
    }
}
