using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Update_Receipt_Rename_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Receipt",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Receipt",
                newName: "Price");
        }
    }
}
