using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LaboratoryPhotoName",
                table: "Laboratories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryStatusId",
                table: "Laboratories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LaboratoryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryStatuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "406d68c2-4a24-45a3-ae91-7aa5296782d8");

            migrationBuilder.InsertData(
                table: "LaboratoryStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Исправное" },
                    { 2, "Техобслуживание" },
                    { 3, "Ремонт" },
                    { 4, "Списание" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_LaboratoryStatusId",
                table: "Laboratories",
                column: "LaboratoryStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratories_LaboratoryStatuses_LaboratoryStatusId",
                table: "Laboratories",
                column: "LaboratoryStatusId",
                principalTable: "LaboratoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laboratories_LaboratoryStatuses_LaboratoryStatusId",
                table: "Laboratories");

            migrationBuilder.DropTable(
                name: "LaboratoryStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Laboratories_LaboratoryStatusId",
                table: "Laboratories");

            migrationBuilder.DropColumn(
                name: "LaboratoryPhotoName",
                table: "Laboratories");

            migrationBuilder.DropColumn(
                name: "LaboratoryStatusId",
                table: "Laboratories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "ec841cf8-c18d-489c-99d2-ff63e9584527");
        }
    }
}
