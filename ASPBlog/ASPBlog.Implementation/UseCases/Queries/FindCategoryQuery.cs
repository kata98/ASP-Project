using ASPBlog.Application.Exceptions;
using ASPBlog.Application.UseCases.DTO;
using ASPBlog.Application.UseCases.Queries;
using ASPBlog.DataAccess;
using ASPBlog.Domain;
using ASPBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPBlog.Implementation.UseCases.Queries
{
    public class FindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        public FindCategoryQuery(ASPBlogDbContext context) : base(context)
        {

        }
        public int Id => 4;

        public string Name => "Find category query";

        public string Description => "Query used for selecting category by Id.";

        public CategoryDto Execute(int id)
        {
            var query = Context.Categories.Find(id);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(Category), id);
            }



            return new CategoryDto
            {
                Id = query.Id,
                Name = query.Name,
                Posts = query.Posts.Select(x => new FindCategoryUserPostDto
                {
                    Title = x.Title,
                    ContentExcerpt = x.Content.Remove(15),
                    TagList = x.PostTags.Select(y => y.Tag.Name),
                    AvgGrade = x.Gradings.Select(z => z.Grade).DefaultIfEmpty(0).Average()
                })
            };
        }
    }
}
