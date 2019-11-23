//using System;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace MvcMovie.Migrations
//{
//    public partial class testMigration : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Speaker");

//            migrationBuilder.DropTable(
//                name: "User");

//            migrationBuilder.CreateIndex(
//                name: "IX_Talk_ConferenceId",
//                table: "Talk",
//                column: "ConferenceId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Talk_RoomID",
//                table: "Talk",
//                column: "RoomID");

//            migrationBuilder.CreateIndex(
//                name: "IX_Party_ConferenceId",
//                table: "Party",
//                column: "ConferenceId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Dinner_ConferenceId",
//                table: "Dinner",
//                column: "ConferenceId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Dinner_RoomID",
//                table: "Dinner",
//                column: "RoomID");

//            migrationBuilder.CreateIndex(
//                name: "IX_Chat_ConferenceId",
//                table: "Chat",
//                column: "ConferenceId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Chat_RoomID",
//                table: "Chat",
//                column: "RoomID");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Chat_Conference_ConferenceId",
//                table: "Chat",
//                column: "ConferenceId",
//                principalTable: "Conference",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Chat_Room_RoomID",
//                table: "Chat",
//                column: "RoomID",
//                principalTable: "Room",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Dinner_Conference_ConferenceId",
//                table: "Dinner",
//                column: "ConferenceId",
//                principalTable: "Conference",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Dinner_Room_RoomID",
//                table: "Dinner",
//                column: "RoomID",
//                principalTable: "Room",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Party_Conference_ConferenceId",
//                table: "Party",
//                column: "ConferenceId",
//                principalTable: "Conference",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Talk_Conference_ConferenceId",
//                table: "Talk",
//                column: "ConferenceId",
//                principalTable: "Conference",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Talk_Room_RoomID",
//                table: "Talk",
//                column: "RoomID",
//                principalTable: "Room",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Chat_Conference_ConferenceId",
//                table: "Chat");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Chat_Room_RoomID",
//                table: "Chat");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Dinner_Conference_ConferenceId",
//                table: "Dinner");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Dinner_Room_RoomID",
//                table: "Dinner");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Party_Conference_ConferenceId",
//                table: "Party");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Talk_Conference_ConferenceId",
//                table: "Talk");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Talk_Room_RoomID",
//                table: "Talk");

//            migrationBuilder.DropIndex(
//                name: "IX_Talk_ConferenceId",
//                table: "Talk");

//            migrationBuilder.DropIndex(
//                name: "IX_Talk_RoomID",
//                table: "Talk");

//            migrationBuilder.DropIndex(
//                name: "IX_Party_ConferenceId",
//                table: "Party");

//            migrationBuilder.DropIndex(
//                name: "IX_Dinner_ConferenceId",
//                table: "Dinner");

//            migrationBuilder.DropIndex(
//                name: "IX_Dinner_RoomID",
//                table: "Dinner");

//            migrationBuilder.DropIndex(
//                name: "IX_Chat_ConferenceId",
//                table: "Chat");

//            migrationBuilder.DropIndex(
//                name: "IX_Chat_RoomID",
//                table: "Chat");

//            migrationBuilder.CreateTable(
//                name: "Speaker",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Birthdate = table.Column<DateTime>(nullable: false),
//                    Description = table.Column<string>(nullable: true),
//                    Email = table.Column<string>(nullable: true),
//                    Genre = table.Column<string>(nullable: true),
//                    Lastname = table.Column<string>(nullable: true),
//                    Name = table.Column<string>(nullable: true),
//                    Phone = table.Column<string>(nullable: true),
//                    University = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Speaker", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "User",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Birthdate = table.Column<DateTime>(nullable: false),
//                    Email = table.Column<string>(nullable: true),
//                    Genre = table.Column<string>(nullable: true),
//                    Lastname = table.Column<string>(nullable: true),
//                    Name = table.Column<string>(nullable: true),
//                    Phone = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_User", x => x.Id);
//                });
//        }
//    }
//}
