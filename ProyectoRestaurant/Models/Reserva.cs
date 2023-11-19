using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ProyectoRestaurant.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CantidadDePersonas { get; set; }

        public Fecha fechaReserva { get; set; }

        public Mesa mesaReserva { get; set; }

    }
}