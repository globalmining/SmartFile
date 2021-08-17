using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManagementApp.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockDetails",
                columns: table => new
                {
                    StockDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockMainID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetails", x => x.StockDetailID);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "StockMains",
                columns: table => new
                {
                    StockMainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebtorAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockDebtTot = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditorAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CredTot = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitBal70 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankDebitAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExcessDB = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMains", x => x.StockMainID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDetails");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "StockMains");
        }
    }
}
