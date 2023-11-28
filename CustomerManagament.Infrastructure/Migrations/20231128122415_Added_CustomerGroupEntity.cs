using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Added_CustomerGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Tenants_TenantId",
                table: "CustomerGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerGroup",
                table: "CustomerGroup");

            migrationBuilder.RenameTable(
                name: "CustomerGroup",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerGroup_TenantId",
                table: "Groups",
                newName: "IX_Groups_TenantId");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GroupId",
                table: "Customers",
                column: "GroupId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Groups_GroupId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Tenants_TenantId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GroupId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "CustomerGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_TenantId",
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
        }
    }
}
