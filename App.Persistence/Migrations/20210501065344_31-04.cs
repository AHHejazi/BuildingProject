using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _3104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingOuts",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutbuildingsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingOuts", x => new { x.BuildingId, x.ComponentId, x.OutbuildingsTypeId });
                    table.ForeignKey(
                        name: "FK_BuildingOuts_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Building",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingOuts_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "lookup",
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingOuts_OutbuildingsType_OutbuildingsTypeId",
                        column: x => x.OutbuildingsTypeId,
                        principalSchema: "lookup",
                        principalTable: "OutbuildingsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingOuts_ComponentId",
                table: "BuildingOuts",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingOuts_OutbuildingsTypeId",
                table: "BuildingOuts",
                column: "OutbuildingsTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingOuts");
        }
    }
}
