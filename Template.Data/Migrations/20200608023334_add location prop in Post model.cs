using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Data.Migrations
{
    public partial class addlocationpropinPostmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Posts");
        }
    }
}
