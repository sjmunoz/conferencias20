﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class chats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomID = table.Column<int>(nullable: false),
                    ConferenceId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EndEventDate = table.Column<DateTime>(nullable: false),
                    Track = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    ModeratorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
