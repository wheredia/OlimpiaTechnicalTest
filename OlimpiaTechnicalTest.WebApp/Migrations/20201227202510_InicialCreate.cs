using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpiaTechnicalTest.WebApp.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aficionados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    NroIdentificación = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    NroTelefonico = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TemperaturaCelsius = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aficionados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    CapacidadMaxima = table.Column<int>(nullable: false),
                    PorcentajeOcupacionMaximo = table.Column<int>(nullable: false),
                    OcupacionActual = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    EstadioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesos_Estadios_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "Estadios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAficionados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadioId = table.Column<int>(nullable: false),
                    AficionadoId = table.Column<int>(nullable: false),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Salida = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAficionados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoAficionados_Aficionados_AficionadoId",
                        column: x => x.AficionadoId,
                        principalTable: "Aficionados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadoAficionados_Estadios_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "Estadios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_EstadioId",
                table: "Accesos",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoAficionados_AficionadoId",
                table: "EstadoAficionados",
                column: "AficionadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoAficionados_EstadioId",
                table: "EstadoAficionados",
                column: "EstadioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "EstadoAficionados");

            migrationBuilder.DropTable(
                name: "Aficionados");

            migrationBuilder.DropTable(
                name: "Estadios");
        }
    }
}
