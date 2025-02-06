using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Remove_CustomerGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroups_Tenants_TenantId",
                table: "CustomerGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroups_CustomerGroupId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerGroups",
                table: "CustomerGroups");

            migrationBuilder.RenameTable(
                name: "CustomerGroups",
                newName: "CustomerGroup");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerGroups_TenantId",
                table: "CustomerGroup",
                newName: "IX_CustomerGroup_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerGroup",
                table: "CustomerGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroup_Tenants_TenantId",
                table: "CustomerGroup",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerGroup_CustomerGroupId",
                table: "Customers",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Tenants_TenantId",
                table: "CustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroup_CustomerGroupId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerGroup",
                table: "CustomerGroup");

            migrationBuilder.RenameTable(
                name: "CustomerGroup",
                newName: "CustomerGroups");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerGroup_TenantId",
                table: "CustomerGroups",
                newName: "IX_CustomerGroups_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerGroups",
                table: "CustomerGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroups_Tenants_TenantId",
                table: "CustomerGroups",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerGroups_CustomerGroupId",
                table: "Customers",
                column: "CustomerGroupId",
                principalTable: "CustomerGroups",
                principalColumn: "Id");
        }
    }
}
