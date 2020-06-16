using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Data.Migrations
{
    public partial class Categorynamepropchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CategName",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategName",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
