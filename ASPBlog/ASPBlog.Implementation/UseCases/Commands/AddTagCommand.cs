
using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Implementation.Validators;
using ASPBlog.Domain.Entities;
using FluentValidation;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class AddTagCommand : EfUseCase, IAddTagCommand
    {
        private readonly TagValidator _validator;
        private readonly IApplicationUser _user;
        public AddTagCommand(ASPBlogDbContext context, TagValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 1;

        public string Name => "Add Tag";

        public string Description => "Adding Tag, only allowed to admin";

        public void Execute(AddTagDto Tag)
        {
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }
            _validator.ValidateAndThrow(Tag);

            var tag = new Tag
            {
                Name = Tag.Name.Trim()
            };

            Context.Tags.Add(tag);
            Context.SaveChanges();

        }
    }
}
