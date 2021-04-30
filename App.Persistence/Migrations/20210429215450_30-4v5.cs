using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _304v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                schema: "lookup",
                table: "Component");

            migrationBuilder.AddColumn<bool>(
                name: "IsOutBuildingType",
                schema: "lookup",
                table: "Component",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOutBuildingType",
                schema: "lookup",
                table: "Component");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "lookup",
                table: "Component",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
