using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _304 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outbuildings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outbuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutbuildingsTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalSurfaceArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outbuildings_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Building",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outbuildings_OutbuildingsType_OutbuildingsTypeId",
                        column: x => x.OutbuildingsTypeId,
                        principalSchema: "lookup",
                        principalTable: "OutbuildingsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Outbuildings_BuildingId",
                table: "Outbuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbuildings_OutbuildingsTypeId",
                table: "Outbuildings",
                column: "OutbuildingsTypeId");
        }
    }
}
