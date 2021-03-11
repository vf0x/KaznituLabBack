﻿// <auto-generated />
using System;
using EFData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFData.Migrations
{
    [DbContext(typeof(KaznituLabContext))]
    [Migration("20210219045029_test5")]
    partial class test5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFData.Entity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EFData.Entity.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmbientTemperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateOfConformity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Destinations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipmentStatusId")
                        .HasColumnType("int");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerVoltage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelativeHumidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SafetyFuses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<string>("Zoom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentStatusId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("EFData.Entity.EquipmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Исправное"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Техобслуживание"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Ремонт"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Списание"
                        });
                });

            modelBuilder.Entity("EFData.Entity.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accreditation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FieldOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaboratoryPhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LaboratoryStatusId")
                        .HasColumnType("int");

                    b.Property<string>("LocationPhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Office")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionLaboratory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryStatusId");

                    b.ToTable("Laboratories");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("LaboratoryEmployees");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryEqiupment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("LaboratoryEqiupments");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("LaboratoryServices");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaboratoryStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Исправное"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Техобслуживание"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Ремонт"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Списание"
                        });
                });

            modelBuilder.Entity("EFData.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                            ConcurrencyStamp = "5a811023-fb29-407e-9a9f-97d0fe8bdbc3",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("EFData.Entity.AppUser", b =>
                {
                    b.HasOne("EFData.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFData.Entity.Equipment", b =>
                {
                    b.HasOne("EFData.Entity.EquipmentStatus", "EquipmentStatus")
                        .WithMany()
                        .HasForeignKey("EquipmentStatusId");

                    b.Navigation("EquipmentStatus");
                });

            modelBuilder.Entity("EFData.Entity.Laboratory", b =>
                {
                    b.HasOne("EFData.Entity.LaboratoryStatus", "LaboratoryStatus")
                        .WithMany()
                        .HasForeignKey("LaboratoryStatusId");

                    b.Navigation("LaboratoryStatus");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryEmployee", b =>
                {
                    b.HasOne("EFData.Entity.Laboratory", "Laboratory")
                        .WithMany("LaboratoryEmployees")
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryEqiupment", b =>
                {
                    b.HasOne("EFData.Entity.Equipment", "Equipment")
                        .WithMany("LaboratoryEqiupments")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("EFData.Entity.Laboratory", "Laboratory")
                        .WithMany("LaboratoryEqiupments")
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Equipment");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("EFData.Entity.LaboratoryService", b =>
                {
                    b.HasOne("EFData.Entity.Laboratory", "Laboratory")
                        .WithMany("LaboratoryServices")
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFData.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFData.Entity.Equipment", b =>
                {
                    b.Navigation("LaboratoryEqiupments");
                });

            modelBuilder.Entity("EFData.Entity.Laboratory", b =>
                {
                    b.Navigation("LaboratoryEmployees");

                    b.Navigation("LaboratoryEqiupments");

                    b.Navigation("LaboratoryServices");
                });
#pragma warning restore 612, 618
        }
    }
}
