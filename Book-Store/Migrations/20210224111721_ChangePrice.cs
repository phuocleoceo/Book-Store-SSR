using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class ChangePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ace0c58-9a3d-4201-948a-1823f68d8002");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "365a1fc8-1296-40c4-9ea9-c93f192f582a", 0, "19fa91d0-9627-4c15-98a6-1c28ab4c295e", "ApplicationUser", null, false, false, null, null, null, null, null, false, "15296b8e-9347-4fae-a83f-27f90cc68d08", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ListPrice", "Price" },
                values: new object[] { 23000f, 16000f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ListPrice", "Price" },
                values: new object[] { 23000f, 16000f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListPrice",
                value: 70000f);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ListPrice",
                value: 100000f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "365a1fc8-1296-40c4-9ea9-c93f192f582a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "8ace0c58-9a3d-4201-948a-1823f68d8002", 0, "f3f4cb00-c9ce-43fa-9e15-2be3a2167e5a", "ApplicationUser", null, false, false, null, null, null, null, null, false, "3f39dfc1-0021-4588-a747-6546b0b2ec83", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ListPrice", "Price" },
                values: new object[] { 10000f, 18000f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ListPrice", "Price" },
                values: new object[] { 10000f, 18000f });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListPrice",
                value: 40000f);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ListPrice",
                value: 50000f);
        }
    }
}
