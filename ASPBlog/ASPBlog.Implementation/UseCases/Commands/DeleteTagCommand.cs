using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class DeleteTagCommand : EfUseCase, IDeleteTagCommand
    {
        private readonly IApplicationUser _user;
        public DeleteTagCommand(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 1;

        public string Name => "Delete Tag";

        public string Description => "Delete Tag only for admin users";

        public void Execute(int request)
        {
            var tag = Context.Tags.Find(request);
            if (tag == null)
            {
                throw new EntityNotFoundException(nameof(Tag), request);
            }
            if (_user.RoleId != 1)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Tags.Remove(tag);

            Context.SaveChanges();
        }
    }
}
