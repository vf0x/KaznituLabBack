using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentFiles");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accreditation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionLaboratory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryEmployees_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryEqiupments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryId = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryEqiupments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryEqiupments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryEqiupments_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryServices_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "ec841cf8-c18d-489c-99d2-ff63e9584527");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryEmployees_LaboratoryId",
                table: "LaboratoryEmployees",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryEqiupments_EquipmentId",
                table: "LaboratoryEqiupments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryEqiupments_LaboratoryId",
                table: "LaboratoryEqiupments",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryServices_LaboratoryId",
                table: "LaboratoryServices",
                column: "LaboratoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboratoryEmployees");

            migrationBuilder.DropTable(
                name: "LaboratoryEqiupments");

            migrationBuilder.DropTable(
                name: "LaboratoryServices");

            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentFiles_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentFiles_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "b20fca6b-0bb6-4e27-b9bb-cd7006472270");

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Паспорт" });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Фото оборудования" });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFiles_EquipmentId",
                table: "EquipmentFiles",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFiles_FileTypeId",
                table: "EquipmentFiles",
                column: "FileTypeId");
        }
    }
}
