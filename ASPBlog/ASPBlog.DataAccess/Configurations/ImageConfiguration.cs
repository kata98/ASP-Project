using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPBlog.Domain.Entities;

namespace ASPBlog.DataAccess.Configurations
{
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(600);

            builder.HasMany(x => x.PostImages)
                   .WithOne(x => x.Image)
                   .HasForeignKey(x => x.ImgId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
