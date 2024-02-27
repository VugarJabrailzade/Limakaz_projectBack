using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class FixingProb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Tariffs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CountryTariff",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    TariffsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTariff", x => new { x.CountryId, x.TariffsId });
                    table.ForeignKey(
                        name: "FK_CountryTariff_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTariff_Tariffs_TariffsId",
                        column: x => x.TariffsId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTariff_TariffsId",
                table: "CountryTariff",
                column: "TariffsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTariff");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Tariffs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
