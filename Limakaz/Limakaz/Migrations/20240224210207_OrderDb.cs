using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Limakaz.Migrations
{
    public partial class OrderDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrUrl = table.Column<string>(type: "text", nullable: false),
                    TrackingCode = table.Column<string>(type: "text", nullable: true),
                    PriceAzn = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceTry = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostAzn = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostTry = table.Column<decimal>(type: "numeric", nullable: false),
                    PrCount = table.Column<int>(type: "integer", nullable: false),
                    PrColor = table.Column<string>(type: "text", nullable: false),
                    PrSize = table.Column<string>(type: "text", nullable: false),
                    PrComment = table.Column<string>(type: "text", nullable: true),
                    PrType = table.Column<string>(type: "text", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Seller = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
