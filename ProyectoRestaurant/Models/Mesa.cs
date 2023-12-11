using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ProyectoRestaurant.Models
{
    public class Mesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroDeMesa { get; set; }

        public int MaximoPersonas { get; set; }

        public Boolean? Libre { get; set; } 

    }
}