using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Implementation.Validators;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class AddCommentCommand : EfUseCase, IAddCommentCommand
    {
        private readonly CommentsValidator _validator;
        private readonly IApplicationUser _user;
        public AddCommentCommand(ASPBlogDbContext context, CommentsValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 3;

        public string Name => "Add Comment command";

        public string Description => "Adding comments used by all users in system";

        public void Execute(AddCommentsDto request)
        {
            _validator.ValidateAndThrow(request);

            var comment = new Comment
            {
                UserId = _user.Id,
                PostId = request.PostId,
                Text = request.Text
            };

            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
