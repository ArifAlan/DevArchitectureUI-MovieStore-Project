using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations.Ms
{
    public partial class SetEntitiesForFKtest22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
