using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "9425f696-933b-49cd-a94c-a9afbeae8734");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "0ab9c83f-4d0d-4140-afe4-ca44db8157b2");
        }
    }
}
