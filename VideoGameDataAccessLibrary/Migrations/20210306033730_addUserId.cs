using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameDataAccessLibrary.Migrations
{
    public partial class addUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "VideoGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VideoGames");
        }
    }
}
