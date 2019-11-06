using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class conference_always_has_eventcenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventCenterId",
                table: "Conference",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conference_EventCenterId",
                table: "Conference",
                column: "EventCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conference_EventCenter_EventCenterId",
                table: "Conference",
                column: "EventCenterId",
                principalTable: "EventCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conference_EventCenter_EventCenterId",
                table: "Conference");

            migrationBuilder.DropIndex(
                name: "IX_Conference_EventCenterId",
                table: "Conference");

            migrationBuilder.DropColumn(
                name: "EventCenterId",
                table: "Conference");
        }
    }
}
