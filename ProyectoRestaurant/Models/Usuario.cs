using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ProyectoRestaurant.Models { 
    public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public int dni{get; set; }
    }
}