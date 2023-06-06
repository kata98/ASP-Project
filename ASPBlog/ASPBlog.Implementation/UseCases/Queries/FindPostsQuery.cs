using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.Queries;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using System.Linq;

namespace ASPBlog.Implementation.UseCases.Queries
{
    public class FindPostsQuery : EfUseCase, IFindPostsQuery
    {
        public FindPostsQuery(ASPBlogDbContext context) : base(context)
        {

        }
        public int Id => 4;

        public string Name => "Find post query";

        public string Description => "Query used for selecting post by Id.";

        public FindPostDto Execute(int id)
        {
            var query = Context.Posts.Find(id);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Post), id);
            }

            if (!query.Gradings.Select(r => r.RatingValue).Any())
            {
                return new FindPostDto
                {
                    Id = query.Id,
                    Title = query.Title,
                    Author = query.User.FirstName + " " + query.User.LastName,
                    Body = query.Body,
                    TagList = query.PostTags.Select(y => y.Tag.Name),
                    Images = query.PostImages.Select(z => z.Image.Path),
                    Comments = query.Comments.Select(c => new FindPostCommentsDto
                    {
                        Id = c.Id,
                        User = c.User.FirstName + " " + c.User.LastName,
                        Text = c.Text
                    })
                };
            }
            else
            {
                return new FindPostDto
                {
                    Id = query.Id,
                    Title = query.Title,
                    Author = query.User.FirstName + " " + query.User.LastName,
                    Body = query.Body,
                    TagList = query.PostTags.Select(y => y.Tag.Name),
                    AvgGrade = query.Gradings.Select(r => r.Grade).Average(),
                    Images = query.PostImages.Select(z => z.Image.Path),
                    Comments = query.Comments.Select(c => new FindPostCommentsDto
                    {
                        Id = c.Id,
                        User = c.User.FirstName + " " + c.User.LastName,
                        Text = c.Text
                    })
                };
            }
        }
    }
}
