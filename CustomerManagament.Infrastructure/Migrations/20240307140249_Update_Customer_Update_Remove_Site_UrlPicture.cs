using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Update_Customer_Update_Remove_Site_UrlPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Site",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "URLPicture",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URLPicture",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
