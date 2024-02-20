using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class AddOfficieDbnewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkingDays",
                table: "Officies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "Officies");
        }
    }
}
