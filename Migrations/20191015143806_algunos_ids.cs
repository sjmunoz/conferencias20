using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class algunos_ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Talk_RoomID",
                table: "Talk",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_EventCenterId",
                table: "Room",
                column: "EventCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinner_RoomID",
                table: "Dinner",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Conference_EventCenterId",
                table: "Conference",
                column: "EventCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_RoomID",
                table: "Chat",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Room_RoomID",
                table: "Chat",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conference_EventCenter_EventCenterId",
                table: "Conference",
                column: "EventCenterId",
                principalTable: "EventCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinner_Room_RoomID",
                table: "Dinner",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_EventCenter_EventCenterId",
                table: "Room",
                column: "EventCenterId",
                principalTable: "EventCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_Room_RoomID",
                table: "Talk",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Room_RoomID",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Conference_EventCenter_EventCenterId",
                table: "Conference");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinner_Room_RoomID",
                table: "Dinner");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_EventCenter_EventCenterId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_Room_RoomID",
                table: "Talk");

            migrationBuilder.DropIndex(
                name: "IX_Talk_RoomID",
                table: "Talk");

            migrationBuilder.DropIndex(
                name: "IX_Room_EventCenterId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Dinner_RoomID",
                table: "Dinner");

            migrationBuilder.DropIndex(
                name: "IX_Conference_EventCenterId",
                table: "Conference");

            migrationBuilder.DropIndex(
                name: "IX_Chat_RoomID",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "EventCenterId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "EventCenterId",
                table: "Conference");
        }
    }
}
