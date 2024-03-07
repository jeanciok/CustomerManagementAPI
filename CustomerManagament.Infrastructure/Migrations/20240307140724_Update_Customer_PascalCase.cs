using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    public partial class Update_Customer_PascalCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Customers",
                newName: "Rg");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Customers",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Customers",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Customers",
                newName: "Cep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rg",
                table: "Customers",
                newName: "RG");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Customers",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Customers",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Customers",
                newName: "CEP");
        }
    }
}
