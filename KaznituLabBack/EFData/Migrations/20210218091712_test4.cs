using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaboratoryId",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentStatusId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentStatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "66710992-7106-4343-8736-419bd1bdfb59");

            migrationBuilder.InsertData(
                table: "EquipmentStatus",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Исправное" },
                    { 2, "Техобслуживание" },
                    { 3, "Ремонт" },
                    { 4, "Списание" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentStatusId",
                table: "Equipments",
                column: "EquipmentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentStatus_EquipmentStatusId",
                table: "Equipments",
                column: "EquipmentStatusId",
                principalTable: "EquipmentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentStatus_EquipmentStatusId",
                table: "Equipments");

            migrationBuilder.DropTable(
                name: "EquipmentStatus");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EquipmentStatusId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EquipmentStatusId",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryId",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "406d68c2-4a24-45a3-ae91-7aa5296782d8");
        }
    }
}
