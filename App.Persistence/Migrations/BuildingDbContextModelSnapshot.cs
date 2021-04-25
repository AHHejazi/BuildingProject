﻿// <auto-generated />
using System;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Persistence.Migrations
{
    [DbContext(typeof(BuildingDbContext))]
    partial class BuildingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.App.Common.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AttachmentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentTypeId");

                    b.ToTable("Attachment", "Common");
                });

            modelBuilder.Entity("Domain.App.Common.AttachmentContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("AttachmentContent", "Common");
                });

            modelBuilder.Entity("Domain.App.Common.AttachmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowedFilesExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImageMaxHeight")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ImageMaxWidth")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsImage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<int>("MaxSizeInMegabytes")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AttachmentType", "lookup");
                });

            modelBuilder.Entity("Domain.App.Common.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSecure")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSticky")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SystemSetting", "Common");
                });

            modelBuilder.Entity("Domain.App.Entities.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("TotalSurfaceArea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Apartment", "Building");
                });

            modelBuilder.Entity("Domain.App.Entities.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EstimatedCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("NumberOfApartment")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfFloor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StampingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSurfaceArea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Building", "Building");
                });

            modelBuilder.Entity("Domain.App.Entities.BuildingComponent", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComponentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BuildingId", "ComponentId");

                    b.HasIndex("ComponentId");

                    b.ToTable("BuildingComponent");
                });

            modelBuilder.Entity("Domain.App.Entities.BuildingSupplies", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuppliesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BuildingId", "SuppliesId");

                    b.HasIndex("SuppliesId");

                    b.ToTable("BuildingSupplies");
                });

            modelBuilder.Entity("Domain.App.Entities.Incomes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShareHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Incomes", "Building");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Component", "lookup");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.OutbuildingsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutbuildingsType", "lookup");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectType", "lookup");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Supplement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Supplement", "lookup");
                });

            modelBuilder.Entity("Domain.App.Entities.Outbuildings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OutbuildingsTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSurfaceArea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("OutbuildingsTypeId");

                    b.ToTable("Outbuildings");
                });

            modelBuilder.Entity("Domain.App.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArchitecturalDiagramsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingLicenseAttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BuildingLicenseNumber")
                        .HasColumnType("int");

                    b.Property<string>("BuildingTechnique")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ConstructionDiagramsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConsultingOfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ElictricalDiagramsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstimatedCost")
                        .HasColumnType("int");

                    b.Property<int>("FloorsNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("InstrumentAttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InstrumentNumber")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid?>("MechanicalDiagramsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("ProjectTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyFullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyLatitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyLongitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("QuarterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("SoilReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SurveyReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalArea")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project", "Building");
                });

            modelBuilder.Entity("ProjectProjectType", b =>
                {
                    b.Property<int>("ProjectTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectTypeId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ProjectProjectType");
                });

            modelBuilder.Entity("Domain.App.Common.Attachment", b =>
                {
                    b.HasOne("Domain.App.Common.AttachmentType", "AttachmentType")
                        .WithMany("Attachments")
                        .HasForeignKey("AttachmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.Common.AttachmentContent", "AttachmentContent")
                        .WithOne("Attachment")
                        .HasForeignKey("Domain.App.Common.Attachment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachmentContent");

                    b.Navigation("AttachmentType");
                });

            modelBuilder.Entity("Domain.App.Entities.Apartment", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", "Building")
                        .WithMany("Apartments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Domain.App.Entities.Building", b =>
                {
                    b.HasOne("Domain.App.Entities.Project", "Project")
                        .WithMany("Buildings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.App.Entities.BuildingComponent", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", "Building")
                        .WithMany("BuildingComponents")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.Entities.Lookup.Component", "Component")
                        .WithMany("BuildingComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Component");
                });

            modelBuilder.Entity("Domain.App.Entities.BuildingSupplies", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", "Building")
                        .WithMany("BuildingSupplies")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.Entities.Lookup.Supplement", "Supplies")
                        .WithMany("BuildingSupplies")
                        .HasForeignKey("SuppliesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("Domain.App.Entities.Incomes", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Component", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", null)
                        .WithMany("Components")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Supplement", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", null)
                        .WithMany("Supplies")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("Domain.App.Entities.Outbuildings", b =>
                {
                    b.HasOne("Domain.App.Entities.Building", "Building")
                        .WithMany("Outbuildings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.Entities.Lookup.OutbuildingsType", "OutbuildingsType")
                        .WithMany("Outbuildings")
                        .HasForeignKey("OutbuildingsTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("OutbuildingsType");
                });

            modelBuilder.Entity("ProjectProjectType", b =>
                {
                    b.HasOne("Domain.App.Entities.Lookup.ProjectType", null)
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.App.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.App.Common.AttachmentContent", b =>
                {
                    b.Navigation("Attachment");
                });

            modelBuilder.Entity("Domain.App.Common.AttachmentType", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("Domain.App.Entities.Building", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("BuildingComponents");

                    b.Navigation("BuildingSupplies");

                    b.Navigation("Components");

                    b.Navigation("Outbuildings");

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Component", b =>
                {
                    b.Navigation("BuildingComponents");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.OutbuildingsType", b =>
                {
                    b.Navigation("Outbuildings");
                });

            modelBuilder.Entity("Domain.App.Entities.Lookup.Supplement", b =>
                {
                    b.Navigation("BuildingSupplies");
                });

            modelBuilder.Entity("Domain.App.Entities.Project", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
