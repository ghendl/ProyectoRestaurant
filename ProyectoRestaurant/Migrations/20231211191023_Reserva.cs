using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class Reserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {



 

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
