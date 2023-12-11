using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ProyectoRestaurant.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Mesa { get; set; }
        public DateTime? Dia { get; set; }
        public string? Hora { get; set; }
        public int? Personas { get; set; }

    }
}