using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class add_user_to_conference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Conference",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conference_UserId",
                table: "Conference",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conference_AspNetUsers_UserId",
                table: "Conference",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conference_AspNetUsers_UserId",
                table: "Conference");

            migrationBuilder.DropIndex(
                name: "IX_Conference_UserId",
                table: "Conference");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Conference");
        }
    }
}
