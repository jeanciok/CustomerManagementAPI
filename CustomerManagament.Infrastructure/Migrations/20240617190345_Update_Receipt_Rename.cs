using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Update_Receipt_Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Customers_CustomerId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Tenants_TenantId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Users_CreatedBy",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_TenantId",
                table: "Receipts",
                newName: "IX_Receipts_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CustomerId",
                table: "Receipts",
                newName: "IX_Receipts_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CreatedBy",
                table: "Receipts",
                newName: "IX_Receipts_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Tenants_TenantId",
                table: "Receipts",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_CreatedBy",
                table: "Receipts",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Tenants_TenantId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_CreatedBy",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_TenantId",
                table: "Receipt",
                newName: "IX_Receipt_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CustomerId",
                table: "Receipt",
                newName: "IX_Receipt_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CreatedBy",
                table: "Receipt",
                newName: "IX_Receipt_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Customers_CustomerId",
                table: "Receipt",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Tenants_TenantId",
                table: "Receipt",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Users_CreatedBy",
                table: "Receipt",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
