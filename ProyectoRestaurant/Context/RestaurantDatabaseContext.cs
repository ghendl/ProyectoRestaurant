
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoRestaurant.Models;
using System.Collections.Generic;
namespace ProyectoRestaurant.Context
{
    public class RestaurantDatabaseContext : DbContext
    {
        public RestaurantDatabaseContext(DbContextOptions<RestaurantDatabaseContext>
       options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    
     
        public DbSet<ProyectoRestaurant.Models.Fecha>? Fecha { get; set; }
        public DbSet<ProyectoRestaurant.Models.Item>? Item { get; set; }
        public DbSet<ProyectoRestaurant.Models.Mesa>? Mesa { get; set; }
        public DbSet<ProyectoRestaurant.Models.Pedido>? Pedido { get; set; }
        public DbSet<ProyectoRestaurant.Models.Reserva>? Reserva { get; set; }
    }
}
