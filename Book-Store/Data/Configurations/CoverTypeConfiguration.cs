﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book_Store.Models;

namespace Book_Store.Data.Configurations
{
    public class CoverTypeConfiguration : IEntityTypeConfiguration<CoverType>
    {
        public void Configure(EntityTypeBuilder<CoverType> builder)
        {
            builder.ToTable("CoverTypes");
            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn();
            builder.Property("Name").IsRequired().HasMaxLength(50);

            builder.HasData
            (
                new CoverType { Id = 1, Name = "Bìa mềm" },
                new CoverType { Id = 2, Name = "Bìa cứng" }
            );
        }
    }
}