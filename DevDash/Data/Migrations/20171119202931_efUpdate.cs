using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DevDash.Data.Migrations
{
    public partial class efUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dashboard",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "backgroundImageURL",
                table: "Trello");

            migrationBuilder.DropColumn(
                name: "issuesURL",
                table: "GitHub");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dashboard");

            migrationBuilder.AlterColumn<long>(
                name: "repoID",
                table: "GitHub",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<long>(
                name: "repoID",
                table: "Dashboard",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dashboard",
                table: "Dashboard",
                column: "dashboardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dashboard",
                table: "Dashboard");

            migrationBuilder.AddColumn<string>(
                name: "backgroundImageURL",
                table: "Trello",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "repoID",
                table: "GitHub",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(long),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "issuesURL",
                table: "GitHub",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "repoID",
                table: "Dashboard",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(long),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dashboard",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dashboard",
                table: "Dashboard",
                column: "Id");
        }
    }
}
