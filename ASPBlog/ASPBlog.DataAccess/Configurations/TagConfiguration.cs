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
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.PostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
