using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.Queries;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;
using System;
using System.Linq;

namespace ASPBlog.Implementation.UseCases.Queries
{
    public class FindUserQuery : EfUseCase, IFindUserQuery
    {
        private readonly IApplicationUser _user;
        public FindUserQuery(ASPBlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 3;

        public string Name => "Find post query";

        public string Description => "Query used for selecting user by Id.";

        public FindUserDto Execute(int id)
        {
            var query = Context.Users.Find(id);

            if(_user.RoleId != 1 && _user.Id != query.Id)
            {
                throw new UnauthorizedAccessException();
            }
            if (query == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }


            if (query.ImgId == null)
            {
                if (_user.RoleId != 3)
                {
                    return new FindAdminModeratorDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.Name,
                        Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                        {
                            Title = x.Title,
                            ContentExcerpt = x.Body.Remove(15),
                            TagList = x.PostTags.Select(y => y.Tag.Name),
                            AvgGrade = x.Gradings.Select(z => z.Grade).DefaultIfEmpty(0).Average()
                        }),
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            Text = x.Text
                        }),
                        Gradings = query.Gradings.Select(x => new UsersGradingDto
                        {
                            PostTitle = x.Post.Title,
                            Grade = x.Grade
                        })
                    };
                }
                else
                {
                    return new FindUserDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.Name,
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            Text = x.Text
                        }),
                        Gradings = query.Gradings.Select(x => new UsersGradingDto
                        {
                            PostTitle = x.Post.Title,
                            Grade = x.Grade
                        })
                    };
                }
            }
            else
            {
                if (_user.RoleId != 3)
                {
                    return new FindAdminModeratorDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.Name,
                        Image = query.Image.Path,
                        Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                        {
                            Title = x.Title,
                            ContentExcerpt = x.Body.Remove(15),
                            TagList = x.PostTags.Select(y => y.Tag.Name),
                            AvgGrade = x.Gradings.Select(z => z.Grade).DefaultIfEmpty(0).Average()
                        }),
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            Text = x.Text
                        }),
                        Gradings = query.Gradings.Select(x => new UsersGradingDto
                        {
                            PostTitle = x.Post.Title,
                            Grade = x.Grade
                        })
                    };
                }
                else
                {
                    return new FindUserDto
                    {
                        Id = query.Id,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        Username = query.Username,
                        Email = query.Email,
                        Role = query.Role.Name,
                        Image = query.Image.Path,
                        Comments = query.Comments.Select(x => new UsersCommentDto
                        {
                            PostTitle = x.Post.Title,
                            Text = x.Text
                        }),
                        Gradings = query.Gradings.Select(x => new UsersGradingDto
                        {
                            PostTitle = x.Post.Title,
                            Grade = x.Grade
                        })
                    };
                }
            }
        }
    }
}
