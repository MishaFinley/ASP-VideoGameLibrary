using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameDataAccessLibrary.Migrations
{
    public partial class videourl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "VideoGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "VideoGames");
        }
    }
}
