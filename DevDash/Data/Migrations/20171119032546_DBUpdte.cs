using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DevDash.Data.Migrations
{
    public partial class DBUpdte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authenticated",
                table: "AspNetUsers",
                newName: "TrelloAuthenticated");

            migrationBuilder.AddColumn<bool>(
                name: "GithubAuthenticated",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GithubAuthenticated",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TrelloAuthenticated",
                table: "AspNetUsers",
                newName: "Authenticated");
        }
    }
}
