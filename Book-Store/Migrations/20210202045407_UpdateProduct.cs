using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoverTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Title" },
                values: new object[] { 2, "Aoyama Gosho", 2, 2, "Kudo Shinichi nhưng giờ sống chung với nhà người yêu", "1234567845234", "https://tuoitho.mobi/upload/truyen/tham-tu-lung-danh-conan-tap-2/anh-bia.jpg", 10000f, 18000f, "Thám tử lừng danh Conan Tập 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoverTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Title" },
                values: new object[] { 3, "Triệu Thị Chơi", 8, 1, "Sách dạy nấu ăn đỉnh của đỉnh", "1234567972354", "https://muasachhay.vn/wp-content/uploads/2016/04/sach-ky-thuat-nau-an-toan-tap-mua-sach-hay-754x1024.jpg", 40000f, 55000f, "Kĩ thuật nấu ăn toàn tập" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoverTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Title" },
                values: new object[] { 4, "Dale Carnegie", 6, 2, "Cuốn sách dạy tâm lý gì đó không biết", "1234987625648", "https://product.hstatic.net/1000217031/product/dac_nhan_tam_1ad146f4adc7443ea98c0636f6cba476.jpg", 50000f, 80000f, "Đắc nhân tâm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
