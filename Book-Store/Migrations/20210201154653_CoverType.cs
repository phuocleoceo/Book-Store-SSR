using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class CoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Paperback" });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Hardcover Case Wrap" });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Hardcover Dust Jacket" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverTypes");
        }
    }
}
