using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations.Ms
{
    public partial class SetEntitiesForFKtest21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Movies");
        }
    }
}
