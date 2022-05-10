using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB2_WITHOUTMVC.Migrations
{
    public partial class _2fws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { 1, "Sporty wodne", "Łódka przeznaczona dla jednej osoby", "Kajak", 275m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { 2, "Sporty wodne", "Chroni i dodaje uroku", "Kamizelka ratunkowa", 48.95m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { 3, "Piłka nożna", "Zatwierdzone przez FIFA rozmiar i waga", "Piłka", 19.50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
