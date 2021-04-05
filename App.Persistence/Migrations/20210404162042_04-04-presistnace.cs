using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _0404presistnace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfFloor",
                schema: "Building",
                table: "Building",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "NumberOfFloor",
                schema: "Building",
                table: "Building",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
