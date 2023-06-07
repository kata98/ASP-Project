using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;
using ASPBlog.Implementation.UseCases;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class DeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private readonly IApplicationUser _user;
        public DeleteCommentCommand(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Delete Comment command";

        public string Description => "Comment delete is allowed to user who made it, and admin";

        public void Execute(int request)
        { 
            var comment = Context.Comments.Find(request);
            
            if (comment == null)
            {
                throw new EntityNotFoundException(nameof(Comment), request);
            }
            if (_user.Id != comment.UserId && _user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Comments.Remove(comment);

            Context.SaveChanges();
        }
    }
}
