using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class DeleteGradingCommand : EfUseCase, IDeleteGradingCommand
    {
        private readonly IApplicationUser _user;
        public DeleteGradingCommand(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Delete Rating command";

        public string Description => "Rating delete is allowed to user who made it, and admin";

        public void Execute(int request)
        {
            var grade = Context.Gradings.Find(request);
            
            if (grade == null)
            {
                throw new EntityNotFoundException(nameof(Grading), request);
            }
            if (_user.Id != grade.UserId)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            Context.Gradings.Remove(grade);

            Context.SaveChanges();
        }
    }
}
