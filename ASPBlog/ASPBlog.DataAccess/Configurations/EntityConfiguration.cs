﻿using ASPBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPBlog.DataAccess.Configurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.UpdatedBy).HasMaxLength(60);
            builder.Property(x => x.DeletedBy).HasMaxLength(60);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            ConfigureRules(builder);
        }

        protected abstract void ConfigureRules (EntityTypeBuilder<T> builder);
    }
}
