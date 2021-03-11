using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEqiupments_Equipments_EquipmentId",
                table: "LaboratoryEqiupments");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEqiupments_Laboratories_LaboratoryId",
                table: "LaboratoryEqiupments");

            migrationBuilder.DeleteData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LaboratoryStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryEqiupments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "LaboratoryEqiupments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "EquipmentStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "a0b1ac8a-9619-46ad-bc2e-4b19b8936785");

            migrationBuilder.UpdateData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Действует");

            migrationBuilder.UpdateData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Не Действует");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEqiupments_Equipments_EquipmentId",
                table: "LaboratoryEqiupments",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEqiupments_Laboratories_LaboratoryId",
                table: "LaboratoryEqiupments",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEqiupments_Equipments_EquipmentId",
                table: "LaboratoryEqiupments");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEqiupments_Laboratories_LaboratoryId",
                table: "LaboratoryEqiupments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LaboratoryStatuses");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "EquipmentStatus");

            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryId",
                table: "LaboratoryEqiupments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "LaboratoryEqiupments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "5a811023-fb29-407e-9a9f-97d0fe8bdbc3");

            migrationBuilder.UpdateData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Исправное");

            migrationBuilder.UpdateData(
                table: "LaboratoryStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Техобслуживание");

            migrationBuilder.InsertData(
                table: "LaboratoryStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 3, "Ремонт" },
                    { 4, "Списание" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEqiupments_Equipments_EquipmentId",
                table: "LaboratoryEqiupments",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEqiupments_Laboratories_LaboratoryId",
                table: "LaboratoryEqiupments",
                column: "LaboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
