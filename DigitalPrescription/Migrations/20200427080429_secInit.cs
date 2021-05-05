using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalPrescription.Migrations
{
    public partial class secInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chs");

            migrationBuilder.CreateTable(
                name: "advices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoryOfMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Medicinetype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryOfMedicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ohs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ohs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Mobile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CteMedicineId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicines_medCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "medCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicines_categoryOfMedicines_CteMedicineId",
                        column: x => x.CteMedicineId,
                        principalTable: "categoryOfMedicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicines_CompanyId",
                table: "medicines",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_medicines_CteMedicineId",
                table: "medicines",
                column: "CteMedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advices");

            migrationBuilder.DropTable(
                name: "CCs");

            migrationBuilder.DropTable(
                name: "Cfs");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "Ohs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "medCompanies");

            migrationBuilder.DropTable(
                name: "categoryOfMedicines");

            migrationBuilder.CreateTable(
                name: "Chs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chs", x => x.Id);
                });
        }
    }
}
