using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class first_has_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Sponsor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_ConferenceId",
                table: "Sponsor",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsor_Conference_ConferenceId",
                table: "Sponsor",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsor_Conference_ConferenceId",
                table: "Sponsor");

            migrationBuilder.DropIndex(
                name: "IX_Sponsor_ConferenceId",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Sponsor");
        }
    }
}
