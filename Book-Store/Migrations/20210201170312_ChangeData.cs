using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class ChangeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Self-Help" },
                    { 7, "Sách tâm lý học" },
                    { 8, "Sách dạy nấu ăn" }
                });

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bìa mềm");

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bìa cứng");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Paperback");

            migrationBuilder.UpdateData(
                table: "CoverTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Hardcover Case Wrap");

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Hardcover Dust Jacket" });
        }
    }
}
