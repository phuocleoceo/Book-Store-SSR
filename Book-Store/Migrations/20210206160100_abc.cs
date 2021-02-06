using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13bb2c4a-a943-4c0a-9ebe-15863521fbc1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "ca7d7daa-a456-44a5-a9a4-1adc2ceea758", 0, "d17c93f8-b36e-42e8-bf14-300aebd9eeb8", "ApplicationUser", null, false, false, null, null, null, null, null, false, "a39a598c-7df8-41af-a971-61dee2f8e8d8", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca7d7daa-a456-44a5-a9a4-1adc2ceea758");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "13bb2c4a-a943-4c0a-9ebe-15863521fbc1", 0, "ab212273-c995-4fef-a60f-f2cf3ce8bd7f", "ApplicationUser", null, false, false, null, null, null, null, null, false, "ec37a76a-72de-445e-be60-806c529fd17c", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
