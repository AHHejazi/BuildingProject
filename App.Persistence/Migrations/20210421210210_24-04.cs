using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _2404 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingSupplies_Supplies_SuppliesId",
                table: "BuildingSupplies");

            migrationBuilder.DropTable(
                name: "Supplies",
                schema: "lookup");

            migrationBuilder.AlterColumn<Guid>(
                name: "SuppliesId",
                table: "BuildingSupplies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Supplement",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplement_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Building",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_BuildingId",
                schema: "lookup",
                table: "Supplement",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingSupplies_Supplement_SuppliesId",
                table: "BuildingSupplies",
                column: "SuppliesId",
                principalSchema: "lookup",
                principalTable: "Supplement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingSupplies_Supplement_SuppliesId",
                table: "BuildingSupplies");

            migrationBuilder.DropTable(
                name: "Supplement",
                schema: "lookup");

            migrationBuilder.AlterColumn<int>(
                name: "SuppliesId",
                table: "BuildingSupplies",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Supplies",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "Building",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_BuildingId",
                schema: "lookup",
                table: "Supplies",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingSupplies_Supplies_SuppliesId",
                table: "BuildingSupplies",
                column: "SuppliesId",
                principalSchema: "lookup",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
