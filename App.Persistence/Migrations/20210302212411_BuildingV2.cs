using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class BuildingV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProjectType_ProjectType_ProjectTypesId",
                table: "ProjectProjectType");

            migrationBuilder.RenameColumn(
                name: "ProjectTypesId",
                table: "ProjectProjectType",
                newName: "ProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProjectType_ProjectType_ProjectTypeId",
                table: "ProjectProjectType",
                column: "ProjectTypeId",
                principalSchema: "lookup",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProjectType_ProjectType_ProjectTypeId",
                table: "ProjectProjectType");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                table: "ProjectProjectType",
                newName: "ProjectTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProjectType_ProjectType_ProjectTypesId",
                table: "ProjectProjectType",
                column: "ProjectTypesId",
                principalSchema: "lookup",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
