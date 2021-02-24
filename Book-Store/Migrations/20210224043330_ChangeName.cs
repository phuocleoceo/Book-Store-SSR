using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartss_AspNetUsers_ApplicationUserId",
                table: "ShoppingCartss");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartss_Products_ProductId",
                table: "ShoppingCartss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartss",
                table: "ShoppingCartss");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8531d36-397a-4e77-944e-6f46f35a9a90");

            migrationBuilder.RenameTable(
                name: "ShoppingCartss",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartss_ProductId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartss_ApplicationUserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "8ace0c58-9a3d-4201-948a-1823f68d8002", 0, "f3f4cb00-c9ce-43fa-9e15-2be3a2167e5a", "ApplicationUser", null, false, false, null, null, null, null, null, false, "3f39dfc1-0021-4588-a747-6546b0b2ec83", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ace0c58-9a3d-4201-948a-1823f68d8002");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCartss");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCartss",
                newName: "IX_ShoppingCartss_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCartss",
                newName: "IX_ShoppingCartss_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartss",
                table: "ShoppingCartss",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CompanyId", "District", "Name", "PostalCode", "ProvinceOrCity", "StreetAddress" },
                values: new object[] { "c8531d36-397a-4e77-944e-6f46f35a9a90", 0, "381ac6d6-faa5-4256-a58e-97fb6266f53e", "ApplicationUser", null, false, false, null, null, null, null, null, false, "2c0bf4be-50ca-40bb-acbd-5df2a91df050", false, null, 1, "Liên Chiểu", "Trương Minh Phước", "550000", "Đà Nẵng", "08 Hà Văn Tính" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartss_AspNetUsers_ApplicationUserId",
                table: "ShoppingCartss",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartss_Products_ProductId",
                table: "ShoppingCartss",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
