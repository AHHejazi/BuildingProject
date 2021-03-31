using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _2903V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_BuildingType_BuildingTypeId",
                schema: "Building",
                table: "Building");

            migrationBuilder.DropTable(
                name: "BuildingType",
                schema: "lookup");

            migrationBuilder.DropIndex(
                name: "IX_Building_BuildingTypeId",
                schema: "Building",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                schema: "Building",
                table: "Building");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                schema: "Building",
                table: "Building",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingType",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_BuildingTypeId",
                schema: "Building",
                table: "Building",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_BuildingType_BuildingTypeId",
                schema: "Building",
                table: "Building",
                column: "BuildingTypeId",
                principalSchema: "lookup",
                principalTable: "BuildingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
