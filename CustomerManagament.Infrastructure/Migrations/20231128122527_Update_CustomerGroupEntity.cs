using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Update_CustomerGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Groups_GroupId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Tenants_TenantId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "CustomerGroups");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_TenantId",
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
                name: "FK_Customers_CustomerGroups_GroupId",
                table: "Customers",
                column: "GroupId",
                principalTable: "CustomerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroups_Tenants_TenantId",
                table: "CustomerGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroups_GroupId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerGroups",
                table: "CustomerGroups");

            migrationBuilder.RenameTable(
                name: "CustomerGroups",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerGroups_TenantId",
                table: "Groups",
                newName: "IX_Groups_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Groups_GroupId",
                table: "Customers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Tenants_TenantId",
                table: "Groups",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
