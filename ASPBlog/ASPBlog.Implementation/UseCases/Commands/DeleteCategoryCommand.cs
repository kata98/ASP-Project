using FluentValidation;
using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using System.Linq;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class DeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        private readonly IApplicationUser _user;
        public DeleteCategoryCommand(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 1;

        public string Name => "Delete category command";

        public string Description => "Category delete is allowed only for admin users";

        public void Execute(int request)
        {

            var category = Context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Grading), request);
            }
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }
            if (category.Posts.Any())
            {
                throw new ValidationException("This category can not be removed because it has posts");
            }


            Context.Categories.Remove(category);

            Context.SaveChanges();
        }
    }
}
