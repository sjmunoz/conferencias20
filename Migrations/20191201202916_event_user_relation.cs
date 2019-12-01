using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class event_user_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "TalkerId",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Party");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Dinner");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Chat",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Talk",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Talker",
                table: "Talk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Talk",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Party",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Party",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Dinner",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Dinner",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Chat",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Chat",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talk_UserId",
                table: "Talk",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_UserId",
                table: "Party",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinner_UserId",
                table: "Dinner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserId",
                table: "Chat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Conference_ConferenceId",
                table: "Chat",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinner_Conference_ConferenceId",
                table: "Dinner",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinner_AspNetUsers_UserId",
                table: "Dinner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_Conference_ConferenceId",
                table: "Party",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_AspNetUsers_UserId",
                table: "Party",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_Conference_ConferenceId",
                table: "Talk",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_AspNetUsers_UserId",
                table: "Talk",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Conference_ConferenceId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinner_Conference_ConferenceId",
                table: "Dinner");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinner_AspNetUsers_UserId",
                table: "Dinner");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_Conference_ConferenceId",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_AspNetUsers_UserId",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_Conference_ConferenceId",
                table: "Talk");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_AspNetUsers_UserId",
                table: "Talk");

            migrationBuilder.DropIndex(
                name: "IX_Talk_UserId",
                table: "Talk");

            migrationBuilder.DropIndex(
                name: "IX_Party_UserId",
                table: "Party");

            migrationBuilder.DropIndex(
                name: "IX_Dinner_UserId",
                table: "Dinner");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UserId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "Talker",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Party");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dinner");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chat",
                newName: "Topic");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Talk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Talk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TalkerId",
                table: "Talk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Party",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Party",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Dinner",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Dinner",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Chat",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Chat",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Chat",
                nullable: false,
                defaultValue: 0);
        }
    }
}
