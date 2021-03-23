using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class validate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "108b5704-8c0b-438d-b364-6a23c7443833");

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceOrCity",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "OrderHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "2176efb9-4b37-4483-80fc-0544449c42d8", 0, "570c1463-fff6-4aec-8789-bc49c671416c", "ApplicationUser", null, false, false, null, null, null, null, null, false, "10ab060c-235c-4288-84b0-c7bbeb5c2df3", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2176efb9-4b37-4483-80fc-0544449c42d8");

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceOrCity",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "108b5704-8c0b-438d-b364-6a23c7443833", 0, "7de59cb7-3dc0-4d48-ab0d-4f9208117b8a", "ApplicationUser", null, false, false, null, null, null, null, null, false, "277adbd4-cd5e-437a-b6e6-5bf0e385a592", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });
        }
    }
}
