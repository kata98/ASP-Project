using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Implementation.Validators;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class AddCategoryCommand : EfUseCase, IAddCategoryCommand
    {
        private readonly CategoryValidator _validator;
        private readonly IApplicationUser _user;
        public AddCategoryCommand(ASPBlogDbContext context, CategoryValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 1;

        public string Name => "Add category command";

        public string Description => "Adding category used only by admin user";

        public void Execute(AddCategoryDto request)
        {
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
