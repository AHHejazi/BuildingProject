using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _2903presistnace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                schema: "lookup",
                table: "BuildingType");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                schema: "lookup",
                table: "BuildingType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                schema: "lookup",
                table: "BuildingType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                schema: "lookup",
                table: "BuildingType");

            migrationBuilder.DropColumn(
                name: "NameEn",
                schema: "lookup",
                table: "BuildingType");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "lookup",
                table: "BuildingType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
