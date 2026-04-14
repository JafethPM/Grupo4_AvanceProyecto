using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("CITAS_G4")]
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        public string NombreDeLaPersona { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime FechaDeLaCita { get; set; }
        public DateTime FechaDeRegistro { get; set; }

        public int IdServicio { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio Servicio { get; set; }
    }
}
