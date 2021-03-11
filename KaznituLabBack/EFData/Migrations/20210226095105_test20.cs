using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryServices_Laboratories_LaboratoryId",
                table: "LaboratoryServices");

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentTechnicalMaintenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAfterMaintenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTechnicalMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentTechnicalMaintenance_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "382b0416-6a79-4947-928f-356587164ae3");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTechnicalMaintenance_EquipmentId",
                table: "EquipmentTechnicalMaintenance",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryServices_Laboratories_LaboratoryId",
                table: "LaboratoryServices",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryServices_Laboratories_LaboratoryId",
                table: "LaboratoryServices");

            migrationBuilder.DropTable(
                name: "EquipmentTechnicalMaintenance");

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "ad33c031-0396-47a3-b12a-26d4eeecb34a");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryServices_Laboratories_LaboratoryId",
                table: "LaboratoryServices",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
