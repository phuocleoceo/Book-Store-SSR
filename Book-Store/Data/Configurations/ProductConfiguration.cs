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
                },
                new Product
                {
                    Id = 2,
                    Title = "Thám tử lừng danh Conan Tập 2",
                    Description = "Kudo Shinichi nhưng giờ sống chung với nhà người yêu",
                    ISBN = "1234567845234",
                    Author = "Aoyama Gosho",
                    ListPrice = 10000,
                    Price = 18000,
                    ImageUrl = "https://tuoitho.mobi/upload/truyen/tham-tu-lung-danh-conan-tap-2/anh-bia.jpg",
                    CategoryId = 2,
                    CoverTypeId = 2
                },
                new Product
                {
                    Id = 3,
                    Title = "Kĩ thuật nấu ăn toàn tập",
                    Description = "Sách dạy nấu ăn đỉnh của đỉnh",
                    ISBN = "1234567972354",
                    Author = "Triệu Thị Chơi",
                    ListPrice = 40000,
                    Price = 55000,
                    ImageUrl = "https://muasachhay.vn/wp-content/uploads/2016/04/sach-ky-thuat-nau-an-toan-tap-mua-sach-hay-754x1024.jpg",
                    CategoryId = 8,
                    CoverTypeId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Đắc nhân tâm",
                    Description = "Cuốn sách dạy tâm lý gì đó không biết",
                    ISBN = "1234987625648",
                    Author = "Dale Carnegie",
                    ListPrice = 50000,
                    Price = 80000,
                    ImageUrl = "https://product.hstatic.net/1000217031/product/dac_nhan_tam_1ad146f4adc7443ea98c0636f6cba476.jpg",
                    CategoryId = 6,
                    CoverTypeId = 2
                }
            );
        }
    }
}
