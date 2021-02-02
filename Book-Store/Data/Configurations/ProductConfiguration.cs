using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book_Store.Models;

namespace Book_Store.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey("Id");
            builder.Property("Id").UseIdentityColumn();
            builder.Property("Title").IsRequired().HasMaxLength(100);

            builder.HasOne<Category>(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne<CoverType>(x => x.CoverType)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CoverTypeId);

            builder.HasData
            (
                new Product
                {
                    Id = 1,
                    Title = "Thám tử lừng danh Conan Tập 1",
                    Description = "Kudo Shinichi là thám tử trung học nổi tiếng, vì chơi ngu nên bị biến thành con nít",
                    ISBN = "1234567891011",
                    Author = "Aoyama Gosho",
                    ListPrice = 10000,
                    Price = 18000,
                    ImageUrl = "https://nxbkimdong.com.vn/sites/default/files/1_83.jpg",
                    CategoryId = 2,
                    CoverTypeId = 2
                }
            );
        }
    }
}
