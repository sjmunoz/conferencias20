using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class sacar_relaciones_eventcenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conference_EventCenter_EventCenterId",
                table: "Conference");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_EventCenter_EventCenterId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_EventCenterId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Conference_EventCenterId",
                table: "Conference");

            migrationBuilder.DropColumn(
                name: "EventCenterId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "EventCenterId",
                table: "Conference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventCenterId",
                table: "Room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventCenterId",
                table: "Conference",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Room_EventCenterId",
                table: "Room",
                column: "EventCenterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Room_EventCenter_EventCenterId",
                table: "Room",
                column: "EventCenterId",
                principalTable: "EventCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
