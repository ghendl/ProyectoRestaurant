using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class migracion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mesaReservaNumeroDeMesa",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_mesaReservaNumeroDeMesa",
                table: "Reserva",
                column: "mesaReservaNumeroDeMesa");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Mesa_mesaReservaNumeroDeMesa",
                table: "Reserva",
                column: "mesaReservaNumeroDeMesa",
                principalTable: "Mesa",
                principalColumn: "NumeroDeMesa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Mesa_mesaReservaNumeroDeMesa",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_mesaReservaNumeroDeMesa",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "mesaReservaNumeroDeMesa",
                table: "Reserva");
        }
    }
}
