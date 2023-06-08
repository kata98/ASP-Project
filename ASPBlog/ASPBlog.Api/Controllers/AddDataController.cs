using ASPBlog.DataAccess;
using ASPBlog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;





// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDataController : ControllerBase
    {

        // POST api/<AddDataController>
        [HttpPost]
        public void Post()
        {
            var context = new ASPBlogDbContext();

            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Moderator" },
                new Role { Name = "Reader" }
            };

            var images = new List<Image>
            {
                new Image { Path = "slika1.jpg"},
                new Image { Path = "slika2.jpg"},
                new Image { Path = "slika3.jpg"},
                new Image { Path = "slika4.jpg"},
                new Image { Path = "slika5.jpg"},
                new Image { Path = "slika6.jpg"},
                new Image { Path = "slika7.jpg"},
                new Image { Path = "slika8.jpg"},
                new Image { Path = "slika9.jpg"},
                new Image { Path = "slika10.jpg"}
            };

            var users = new List<User>
            {
                new User { FirstName = "Maxine", LastName = "Mccarthy", Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin"), Email = "admin@gmail.com", Role = roles.First(), Image = images.ElementAt(4)},
                new User { FirstName = "Lara", LastName = "Currey", Username = "laura", Password = BCrypt.Net.BCrypt.HashPassword("laurapass"), Email = "laura@gmail.com", Role = roles.ElementAt(1), Image = images.ElementAt(0)},
                new User { FirstName = "Patrick", LastName = "Schwartz", Username = "patrick", Password = BCrypt.Net.BCrypt.HashPassword("patrickpass"), Email = "patrick@gmail.com", Role = roles.ElementAt(1), Image = images.ElementAt(1)},
                new User { FirstName = "Justine", LastName = "Carol", Username = "justine", Password = BCrypt.Net.BCrypt.HashPassword("justinepass"), Email = "justin@gmail.com", Role = roles.ElementAt(2), Image = images.ElementAt(6)},
                new User { FirstName = "Haven", LastName = "Ward", Username = "haven", Password = BCrypt.Net.BCrypt.HashPassword("havenpass"), Email = "haven@gmail.com", Role = roles.ElementAt(2), Image = images.ElementAt(2)},
                new User { FirstName = "Robin", LastName = "Blair", Username = "robin", Password = BCrypt.Net.BCrypt.HashPassword("robinpass"), Email = "robin@gmail.com", Role = roles.ElementAt(2), Image = images.ElementAt(3)}
            };

            var categories = new List<Category>
            {
                new Category { Name = "Lifestyle"},
                new Category { Name = "Fashion"},
                new Category { Name = "Fitness"}
            };

            var posts = new List<Post>
            {
                new Post { Title = "Stay Productive", Body = "Your top productivity tips.", User = users.ElementAt(1), Category = categories.ElementAt(0)},
                new Post { Title = "Saving Money", Body = "Top 10 ways you save money.", User = users.ElementAt(2), Category = categories.ElementAt(0)},
                new Post { Title = "Self-care", Body = "Your favourite self-care activities.", User = users.ElementAt(1), Category = categories.ElementAt(0)},
                new Post { Title = "Skincare Products", Body = "10 Best Overnight Skincare Tips", User = users.ElementAt(2), Category = categories.ElementAt(1)},
                new Post { Title = "New Designs", Body = "The Latest Trends in Fashion", User = users.ElementAt(1), Category = categories.ElementAt(1)},
                new Post { Title = "Shopping Guide", Body = "Eco Friendly Shopping", User = users.ElementAt(2), Category = categories.ElementAt(1)},
                new Post { Title = "Workout Ideas", Body = "Boot-camp style workouts", User = users.ElementAt(1), Category = categories.ElementAt(2)},
                new Post { Title = "Hiking", Body = "Hiking workouts", User = users.ElementAt(2), Category = categories.ElementAt(2)},
                new Post { Title = "Nutrition", Body = "Meal preparation tips", User = users.ElementAt(1), Category = categories.ElementAt(2)},
            };

            var tags = new List<Tag>
            {
                new Tag { Name = "New" },
                new Tag { Name = "Old" },
                new Tag { Name = "Sport" },
                new Tag { Name = "Trending" },
                new Tag { Name = "Celebrity" },
                new Tag { Name = "Designer" },
                new Tag { Name = "Candy " },
                new Tag { Name = "Fruit" }
            };

            var postTags = new List<PostTag>
            {
                new PostTag { Post = posts.ElementAt(8), Tag = tags.ElementAt(0)},
                new PostTag { Post = posts.ElementAt(7), Tag = tags.ElementAt(1)},
                new PostTag { Post = posts.ElementAt(6), Tag = tags.ElementAt(2)},
                new PostTag { Post = posts.ElementAt(5), Tag = tags.ElementAt(3)},
                new PostTag { Post = posts.ElementAt(4), Tag = tags.ElementAt(4)},
                new PostTag { Post = posts.ElementAt(3), Tag = tags.ElementAt(5)},
                new PostTag { Post = posts.ElementAt(2), Tag = tags.ElementAt(6)},
                new PostTag { Post = posts.ElementAt(1), Tag = tags.ElementAt(7)},
                new PostTag { Post = posts.ElementAt(0), Tag = tags.ElementAt(6)},
                new PostTag { Post = posts.ElementAt(1), Tag = tags.ElementAt(5)},
                new PostTag { Post = posts.ElementAt(2), Tag = tags.ElementAt(4)},
                new PostTag { Post = posts.ElementAt(3), Tag = tags.ElementAt(3)},
            };

            var postImages = new List<PostImage>
            {
                new PostImage { Post = posts.ElementAt(0), Image = images.ElementAt(3) },
                new PostImage { Post = posts.ElementAt(1), Image = images.ElementAt(4) },
                new PostImage { Post = posts.ElementAt(2), Image = images.ElementAt(5) },
                new PostImage { Post = posts.ElementAt(3), Image = images.ElementAt(6) },
                new PostImage { Post = posts.ElementAt(4), Image = images.ElementAt(7) },
                new PostImage { Post = posts.ElementAt(4), Image = images.ElementAt(8) },
                new PostImage { Post = posts.ElementAt(6), Image = images.ElementAt(9) },
                new PostImage { Post = posts.ElementAt(7), Image = images.ElementAt(0) },
                new PostImage { Post = posts.ElementAt(7), Image = images.ElementAt(2) },
                new PostImage { Post = posts.ElementAt(0), Image = images.ElementAt(4) },
                new PostImage { Post = posts.ElementAt(1), Image = images.ElementAt(5) },
            };

            var grades = new List<Grading>
            {
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(1), Grade = 3},
                new Grading { User = users.ElementAt(4), Post = posts.ElementAt(2), Grade = 4},
                new Grading { User = users.ElementAt(5), Post = posts.ElementAt(2), Grade = 5},
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(4), Grade = 3},
                new Grading { User = users.ElementAt(4), Post = posts.ElementAt(4), Grade = 4},
                new Grading { User = users.ElementAt(5), Post = posts.ElementAt(5), Grade = 5},
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(6), Grade = 3},
                new Grading { User = users.ElementAt(4), Post = posts.ElementAt(6), Grade = 4},
                new Grading { User = users.ElementAt(5), Post = posts.ElementAt(6), Grade = 5},
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(7), Grade = 3},
                new Grading { User = users.ElementAt(4), Post = posts.ElementAt(7), Grade = 4},
                new Grading { User = users.ElementAt(5), Post = posts.ElementAt(7), Grade = 1},
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(5), Grade = 5},
                new Grading { User = users.ElementAt(3), Post = posts.ElementAt(2), Grade = 5}
            };

            var comments = new List<Comment>
            {
                new Comment { User = users.ElementAt(1), Post = posts.ElementAt(0), Text = "Awesome"},
                new Comment { User = users.ElementAt(2), Post = posts.ElementAt(1), Text = "Good"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(2), Text = "Useful"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(3), Text = "Did not like it"},
                new Comment { User = users.ElementAt(5), Post = posts.ElementAt(4), Text = "Do you agree?"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(5), Text = "More about this topic"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(5), Text = "Not talked about enough"},
                new Comment { User = users.ElementAt(5), Post = posts.ElementAt(6), Text = "I agree"},
                new Comment { User = users.ElementAt(3), Post = posts.ElementAt(6), Text = "Tank you for this"},
                new Comment { User = users.ElementAt(4), Post = posts.ElementAt(7), Text = "Did not agree"},
            };

            context.Roles.AddRange(roles);
            context.Images.AddRange(images);
            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Tags.AddRange(tags);
            context.PostTags.AddRange(postTags);
            context.PostImages.AddRange(postImages);
            context.Gradings.AddRange(grades);
            context.Comments.AddRange(comments);

            context.SaveChanges();

        }

    }
}
