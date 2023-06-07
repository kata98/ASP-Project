
using Microsoft.EntityFrameworkCore;
using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class DeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private readonly IApplicationUser _user;
        public DeleteUserCommand(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 1;

        public string Name => "Delete user command";

        public string Description => "Command used only by admin";

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(Grading), request);
            }
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            if(user.Posts.Any())
            {
                throw new ValidationException("This user can not be removed because it has posts");
            }
            

            var ratings = Context.Gradings.Where(x => x.UserId == request);
            var comments = Context.Comments.Where(x => x.UserId == request);
            var useCases = Context.UserUseCases.Where(x => x.UserId == request);

            Context.Gradings.RemoveRange(ratings);
            Context.Comments.RemoveRange(comments);
            Context.UserUseCases.RemoveRange(useCases);

            Context.Users.Remove(user);

            Context.SaveChanges();
        }
    }
}
