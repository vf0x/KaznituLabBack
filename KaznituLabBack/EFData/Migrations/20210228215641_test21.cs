using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFData.Migrations
{
    public partial class test21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentStatus_EquipmentStatusId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTechnicalMaintenance_Equipments_EquipmentId",
                table: "EquipmentTechnicalMaintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentTechnicalMaintenance",
                table: "EquipmentTechnicalMaintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentStatus",
                table: "EquipmentStatus");

            migrationBuilder.RenameTable(
                name: "EquipmentTechnicalMaintenance",
                newName: "EquipmentTechnicalMaintenances");

            migrationBuilder.RenameTable(
                name: "EquipmentStatus",
                newName: "EquipmentStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTechnicalMaintenance_EquipmentId",
                table: "EquipmentTechnicalMaintenances",
                newName: "IX_EquipmentTechnicalMaintenances_EquipmentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestBudget",
                table: "Projects",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HaveBudget",
                table: "Projects",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentTechnicalMaintenances",
                table: "EquipmentTechnicalMaintenances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentStatuses",
                table: "EquipmentStatuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BibliographicDbTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliographicDbTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCertificateRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CopyrightHolder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCertificateRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCertificateRegistrations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPatents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeretoryFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyrightHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPatents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPatents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRevenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRevenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRevenues_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFundings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false),
                    FinancingTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFundings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFundings_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFundings_FinancingTypes_FinancingTypeId",
                        column: x => x.FinancingTypeId,
                        principalTable: "FinancingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFundings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Doi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Essn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedMonRK = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFundingCoFinancings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectFundingId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFundingCoFinancings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFundingCoFinancings_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFundingCoFinancings_ProjectFundings_ProjectFundingId",
                        column: x => x.ProjectFundingId,
                        principalTable: "ProjectFundings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFundingStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectFundingId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFundingStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFundingStages_ProjectFundings_ProjectFundingId",
                        column: x => x.ProjectFundingId,
                        principalTable: "ProjectFundings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkBibliographicDbTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    BibliographicDbTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkBibliographicDbTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkBibliographicDbTypes_BibliographicDbTypes_BibliographicDbTypeId",
                        column: x => x.BibliographicDbTypeId,
                        principalTable: "BibliographicDbTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkBibliographicDbTypes_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkCoAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FromSU = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCoAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkCoAuthors_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "21504b53-534a-4584-b430-f585aaaf39bb");

            migrationBuilder.InsertData(
                table: "BibliographicDbTypes",
                columns: new[] { "Id", "Deleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Scopus" },
                    { 2, false, "WoS" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "Id", "Deleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "₸ KZT" },
                    { 2, false, "$ USD" },
                    { 3, false, "₽ RUB" },
                    { 4, false, "€ EUR" }
                });

            migrationBuilder.InsertData(
                table: "FinancingTypes",
                columns: new[] { "Id", "Deleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Заём" },
                    { 2, false, "Кредит" },
                    { 3, false, "Ссуда" },
                    { 4, false, "Аренда" },
                    { 5, false, "Пожертвование, Дарение" },
                    { 6, false, "Субсидия" },
                    { 7, false, "Субвенция" },
                    { 8, false, "Дотация" },
                    { 9, false, "Грант" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCertificateRegistrations_ProjectId",
                table: "ProjectCertificateRegistrations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingCoFinancings_CurrencyTypeId",
                table: "ProjectFundingCoFinancings",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingCoFinancings_ProjectFundingId",
                table: "ProjectFundingCoFinancings",
                column: "ProjectFundingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundings_CurrencyTypeId",
                table: "ProjectFundings",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundings_FinancingTypeId",
                table: "ProjectFundings",
                column: "FinancingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundings_ProjectId",
                table: "ProjectFundings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingStages_ProjectFundingId",
                table: "ProjectFundingStages",
                column: "ProjectFundingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPatents_ProjectId",
                table: "ProjectPatents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevenues_ProjectId",
                table: "ProjectRevenues",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkBibliographicDbTypes_BibliographicDbTypeId",
                table: "WorkBibliographicDbTypes",
                column: "BibliographicDbTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkBibliographicDbTypes_WorkId",
                table: "WorkBibliographicDbTypes",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCoAuthors_WorkId",
                table: "WorkCoAuthors",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkTypeId",
                table: "Works",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentStatuses_EquipmentStatusId",
                table: "Equipments",
                column: "EquipmentStatusId",
                principalTable: "EquipmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTechnicalMaintenances_Equipments_EquipmentId",
                table: "EquipmentTechnicalMaintenances",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentStatuses_EquipmentStatusId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTechnicalMaintenances_Equipments_EquipmentId",
                table: "EquipmentTechnicalMaintenances");

            migrationBuilder.DropTable(
                name: "ProjectCertificateRegistrations");

            migrationBuilder.DropTable(
                name: "ProjectFundingCoFinancings");

            migrationBuilder.DropTable(
                name: "ProjectFundingStages");

            migrationBuilder.DropTable(
                name: "ProjectPatents");

            migrationBuilder.DropTable(
                name: "ProjectRevenues");

            migrationBuilder.DropTable(
                name: "WorkBibliographicDbTypes");

            migrationBuilder.DropTable(
                name: "WorkCoAuthors");

            migrationBuilder.DropTable(
                name: "ProjectFundings");

            migrationBuilder.DropTable(
                name: "BibliographicDbTypes");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");

            migrationBuilder.DropTable(
                name: "FinancingTypes");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentTechnicalMaintenances",
                table: "EquipmentTechnicalMaintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentStatuses",
                table: "EquipmentStatuses");

            migrationBuilder.RenameTable(
                name: "EquipmentTechnicalMaintenances",
                newName: "EquipmentTechnicalMaintenance");

            migrationBuilder.RenameTable(
                name: "EquipmentStatuses",
                newName: "EquipmentStatus");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentTechnicalMaintenances_EquipmentId",
                table: "EquipmentTechnicalMaintenance",
                newName: "IX_EquipmentTechnicalMaintenance_EquipmentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestBudget",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HaveBudget",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentTechnicalMaintenance",
                table: "EquipmentTechnicalMaintenance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentStatus",
                table: "EquipmentStatus",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95FEE468-4DA9-40F6-AACB-42951BBABAF9",
                column: "ConcurrencyStamp",
                value: "382b0416-6a79-4947-928f-356587164ae3");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentStatus_EquipmentStatusId",
                table: "Equipments",
                column: "EquipmentStatusId",
                principalTable: "EquipmentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentTechnicalMaintenance_Equipments_EquipmentId",
                table: "EquipmentTechnicalMaintenance",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
