using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book_Store.Models;

namespace Book_Store.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn();
            builder.Property("Name").IsRequired().HasMaxLength(50);

            builder.HasData
            (
                new Category { Id = 1, Name = "Sách giáo khoa" },
                new Category { Id = 2, Name = "Truyện trinh thám" },
                new Category { Id = 3, Name = "Truyện tranh màu" },
                new Category { Id = 4, Name = "Sách tham khảo" },
                new Category { Id = 5, Name = "Sách cấm" }
            );
        }
    }
}
