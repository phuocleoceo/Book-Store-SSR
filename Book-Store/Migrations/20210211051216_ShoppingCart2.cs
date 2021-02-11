using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class ShoppingCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4dbdd699-d0b5-4dc0-881c-1fe37b401a7c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "c8531d36-397a-4e77-944e-6f46f35a9a90", 0, "381ac6d6-faa5-4256-a58e-97fb6266f53e", "ApplicationUser", null, false, false, null, null, null, null, null, false, "2c0bf4be-50ca-40bb-acbd-5df2a91df050", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8531d36-397a-4e77-944e-6f46f35a9a90");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "4dbdd699-d0b5-4dc0-881c-1fe37b401a7c", 0, "f2fe9894-b58b-43d1-8fad-5de99896ac2d", "ApplicationUser", null, false, false, null, null, null, null, null, false, "c566650d-a3ea-45d8-83db-624e40e0e5e8", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });
        }
    }
}
