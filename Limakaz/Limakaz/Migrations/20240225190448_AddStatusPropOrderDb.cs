using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class AddStatusPropOrderDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficiesId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OfficiesId",
                table: "Order",
                column: "OfficiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Officies_OfficiesId",
                table: "Order",
                column: "OfficiesId",
                principalTable: "Officies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Officies_OfficiesId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OfficiesId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OfficiesId",
                table: "Order");
        }
    }
}
