using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpiaTechnicalTest.WebApp.Migrations
{
    public partial class OlimpiaTechnicalTestDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Aficionados");

            migrationBuilder.DropColumn(
                name: "NroIdentificación",
                table: "Aficionados");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Aficionados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NroIdentificacion",
                table: "Aficionados",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Aficionados");

            migrationBuilder.DropColumn(
                name: "NroIdentificacion",
                table: "Aficionados");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Aficionados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NroIdentificación",
                table: "Aficionados",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
