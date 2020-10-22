using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetcoreMVC.Migrations
{
    public partial class AddCpfFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Funcionarios");
        }
    }
}
