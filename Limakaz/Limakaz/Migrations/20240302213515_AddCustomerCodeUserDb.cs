using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class AddCustomerCodeUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerCode",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerCode",
                table: "Users");
        }
    }
}
