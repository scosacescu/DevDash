using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DevDash.Data.Migrations
{
    public partial class entityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TrelloKey",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GitHub",
                columns: table => new
                {
                    userID = table.Column<string>(nullable: false),
                    repoID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    issuesURL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    repoName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitHub", x => new { x.userID, x.repoID });
                    table.ForeignKey(
                        name: "FK_GitHub_ToUser",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trello",
                columns: table => new
                {
                    userID = table.Column<string>(nullable: false),
                    boardID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    backgroundImageURL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    boardName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trello", x => new { x.userID, x.boardID });
                    table.ForeignKey(
                        name: "FK_Trello_ToUser",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    boardID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    dashboardID = table.Column<Guid>(nullable: false),
                    dashboardName = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    repoID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    userID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dashboard_ToUser",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dashboard_ToTrello",
                        columns: x => new { x.userID, x.boardID },
                        principalTable: "Trello",
                        principalColumns: new[] { "userID", "boardID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dashboard_ToGithub",
                        columns: x => new { x.userID, x.repoID },
                        principalTable: "GitHub",
                        principalColumns: new[] { "userID", "repoID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_userID_boardID",
                table: "Dashboard",
                columns: new[] { "userID", "boardID" });

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_userID_repoID",
                table: "Dashboard",
                columns: new[] { "userID", "repoID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropTable(
                name: "Trello");

            migrationBuilder.DropTable(
                name: "GitHub");

            migrationBuilder.DropColumn(
                name: "TrelloKey",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
