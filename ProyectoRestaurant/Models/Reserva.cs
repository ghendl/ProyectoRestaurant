using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestaurant.Models
{
    public class Reserva
    {
         
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MesaNumero { get; set; }
        public DateTime Dia { get; set; }
        public string? Hora { get; set; }
        public int? CantidadPersonas { get; set; }

    
    }
}
