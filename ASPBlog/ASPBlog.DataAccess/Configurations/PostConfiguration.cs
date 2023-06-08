using ASPBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.DataAccess.Configurations
{
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Post> builder)
        {

            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Title).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Body).IsRequired();

            builder.HasMany(x => x.Gradings)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PostTags)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PostImages)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.Post)
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
