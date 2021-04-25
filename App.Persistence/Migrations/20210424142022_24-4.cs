using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class _244 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchitecturalDiagrams",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BuildingLicenseAttachment",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ConstructionDiagrams",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ElictricalDiagrams",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "InstrumentAttachment",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MechanicalDiagrams",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "SoilReport",
                schema: "Building",
                table: "Project");

            migrationBuilder.AddColumn<Guid>(
                name: "ArchitecturalDiagramsId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingLicenseAttachmentId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConstructionDiagramsId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ElictricalDiagramsId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentAttachmentId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MechanicalDiagramsId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoilReportId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyReportId",
                schema: "Building",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchitecturalDiagramsId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BuildingLicenseAttachmentId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ConstructionDiagramsId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ElictricalDiagramsId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "InstrumentAttachmentId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MechanicalDiagramsId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "SoilReportId",
                schema: "Building",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "SurveyReportId",
                schema: "Building",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "ArchitecturalDiagrams",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingLicenseAttachment",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstructionDiagrams",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElictricalDiagrams",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentAttachment",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicalDiagrams",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoilReport",
                schema: "Building",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
