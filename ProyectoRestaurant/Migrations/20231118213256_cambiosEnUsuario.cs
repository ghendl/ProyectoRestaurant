using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class cambiosEnUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Usuarios",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            /// <inheritdoc />
        }
    }
}