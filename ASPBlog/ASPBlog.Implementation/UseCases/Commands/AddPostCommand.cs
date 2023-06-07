using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Implementation.Validators;
using System.Collections.Generic;
using System.Linq;
using ASPBlog.Domain.Entities;
using FluentValidation;

namespace ASPBlog.Implementation.UseCases.Commands
{
    public class AddPostCommand : EfUseCase, IAddPostCommand
    {
        private readonly PostsValidator _validator;
        private readonly IApplicationUser _user;
        public AddPostCommand(ASPBlogDbContext context, PostsValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }
        public int Id => 2;

        public string Name => "Add Post command";

        public string Description => "Adding Post and corresponding Tags used by all users in system";

        public void Execute(AddPostDto request)
        {
            if (_user.RoleId == 3)
            {
                throw new ForbiddenExecutionException(Name, _user.Identity);
            }

            _validator.ValidateAndThrow(request);

            var post = new Post
            {
                Title = request.Title,
                Body = request.Body,
                UserId = _user.Id,
                CategoryId = request.CategoryId
            };

            var postTag = new List<PostTag>();

            foreach (var d in request.Tags)
            {
                postTag.Add(new PostTag
                {
                    Post = post,
                    TagId = Context.Tags.Where(x => x.Name == d).Select(x => x.Id).FirstOrDefault()
                });
            }

            if (!string.IsNullOrEmpty(request.ImgFileName))
            {

                var postImage = new PostImage
                {
                    Post = post,
                    Image = new Image
                    {
                        Path = request.ImgFileName
                    }
                };
                Context.PostImages.AddRange(postImage);
            }

            Context.Posts.Add(post);
            Context.PostTags.AddRange(postTag);
            Context.SaveChanges();
        }
    }
}
