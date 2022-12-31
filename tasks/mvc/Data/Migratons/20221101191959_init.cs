using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migratons
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Raqam = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 1, "million", 1000000 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 2, "ming", 1000 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 3, "yuz", 100 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 4, "to'qson", 90 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 5, "sakson", 80 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 6, "yetmish", 70 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 7, "oltmish", 60 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 8, "ellik", 50 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 9, "qirq", 40 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 10, "o'ttiz", 30 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 11, "yigirma", 20 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 12, "o'n", 10 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 13, "to'qqiz", 9 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 14, "sakkiz", 8 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 15, "yetti", 7 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 16, "olti", 6 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 17, "besh", 5 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 18, "to'rt", 4 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 19, "uch", 3 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 20, "ikki", 2 });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Id", "Name", "Raqam" },
                values: new object[] { 21, "bir", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");
        }
    }
}
