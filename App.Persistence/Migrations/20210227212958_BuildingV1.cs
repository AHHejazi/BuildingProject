using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class BuildingV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                schema: "Building",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "StocksNumber",
                schema: "Building",
                table: "Project",
                newName: "ProjectTypeId");

            migrationBuilder.CreateTable(
                name: "ProjectType",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProjectType",
                columns: table => new
                {
                    ProjectTypesId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProjectType", x => new { x.ProjectTypesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectProjectType_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalSchema: "Building",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProjectType_ProjectType_ProjectTypesId",
                        column: x => x.ProjectTypesId,
                        principalSchema: "lookup",
                        principalTable: "ProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProjectType_ProjectsId",
                table: "ProjectProjectType",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProjectType");

            migrationBuilder.DropTable(
                name: "ProjectType",
                schema: "lookup");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                schema: "Building",
                table: "Project",
                newName: "StocksNumber");

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                schema: "Building",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                schema: "Building",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
