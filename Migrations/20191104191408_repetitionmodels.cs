using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class repetitionmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Repetition_ConferenceId",
                table: "Repetition",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repetition_Conference_ConferenceId",
                table: "Repetition",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repetition_Conference_ConferenceId",
                table: "Repetition");

            migrationBuilder.DropIndex(
                name: "IX_Repetition_ConferenceId",
                table: "Repetition");
        }
    }
}
