using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEmployees_Laboratories_LaboratoryId",
                table: "LaboratoryEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "ad33c031-0396-47a3-b12a-26d4eeecb34a");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEmployees_Laboratories_LaboratoryId",
                table: "LaboratoryEmployees",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEmployees_Laboratories_LaboratoryId",
                table: "LaboratoryEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryEmployees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "4141cf33-3366-4a89-9fac-c095e20d9bbd");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEmployees_Laboratories_LaboratoryId",
                table: "LaboratoryEmployees",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
