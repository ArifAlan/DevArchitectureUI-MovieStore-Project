using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations.Ms
{
    public partial class addednewpropsinentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Movies");
        }
    }
}
