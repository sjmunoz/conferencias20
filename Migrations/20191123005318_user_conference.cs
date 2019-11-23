using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class user_conference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Spots",
                table: "Conference",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConferenceUser",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceUser", x => new { x.UserId, x.ConferenceId });
                    table.ForeignKey(
                        name: "FK_ConferenceUser_Conference_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceUser_ConferenceId",
                table: "ConferenceUser",
                column: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceUser");

            migrationBuilder.DropColumn(
                name: "Spots",
                table: "Conference");
        }
    }
}
