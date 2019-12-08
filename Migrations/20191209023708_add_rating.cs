using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class add_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TalkUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "PartyUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "DinnerUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ChatUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TalkUser");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PartyUser");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "DinnerUser");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ChatUser");
        }
    }
}
