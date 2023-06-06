using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.UseCases.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FindCategoryUserPostDto> Posts { get; set; }
    }

    public class AddCategoryDto
    {
        public string Name { get; set; }
    }
}
