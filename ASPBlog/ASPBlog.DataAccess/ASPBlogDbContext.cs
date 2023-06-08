using ASPBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPBlog.DataAccess
{
    public class ASPBlogDbContext : DbContext
    {
        public ASPBlogDbContext(DbContextOptions<ASPBlogDbContext> options) : base(options)
        {
        }

        public ASPBlogDbContext()
        {
        }

        public IApplicationUser User { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8J573MD\SQLEXPRESS;Initial Catalog=ASPBlog;Integrated Security=True;Encrypt=False");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });
            modelBuilder.Entity<PostImage>().HasKey(x => new { x.PostId, x.ImgId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            modelBuilder.Entity<Comment>().Property(x => x.Text).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                        case EntityState.Deleted:
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Grading> Gradings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}