using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fechaReservaID",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_fechaReservaID",
                table: "Reserva",
                column: "fechaReservaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Fecha_fechaReservaID",
                table: "Reserva",
                column: "fechaReservaID",
                principalTable: "Fecha",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Fecha_fechaReservaID",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_fechaReservaID",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "fechaReservaID",
                table: "Reserva");
        }
    }
}
