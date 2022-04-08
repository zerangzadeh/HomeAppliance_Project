using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    public partial class inventoryOperationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.CreateTable(
                name: "InventoryOperations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationType = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    OperatorID = table.Column<long>(type: "bigint", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OrederID = table.Column<long>(type: "bigint", nullable: false),
                    InventoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryOperations_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_InventoryID",
                table: "InventoryOperations",
                column: "InventoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOperations");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<bool>(type: "bit", nullable: false),
                    OperatorID = table.Column<long>(type: "bigint", nullable: false),
                    OrederID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Operations_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_InventoryID",
                table: "Operations",
                column: "InventoryID");
        }
    }
}
