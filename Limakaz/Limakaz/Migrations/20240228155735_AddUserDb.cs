using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class AddUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTariff");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CountryPrefix",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    FinCode = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    RulesAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    OfficeId = table.Column<int>(type: "integer", nullable: false),
                    OfficiesId = table.Column<int>(type: "integer", nullable: false),
                    PersonType = table.Column<int>(type: "integer", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Officies_OfficiesId",
                        column: x => x.OfficiesId,
                        principalTable: "Officies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OfficiesId",
                table: "Users",
                column: "OfficiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Countries_CountryId",
                table: "Tariffs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CountryId",
                table: "Tariffs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryPrefix",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
