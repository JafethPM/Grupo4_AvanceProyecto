using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("SERVICIOS_G4")]
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public decimal IVA { get; set; }

        [Required]
        public int Especialidad { get; set; }

        public string? Especialista { get; set; }
        public string? Clinica { get; set; }


        public DateTime FechaDeRegistro { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        public bool Estado { get; set; }
    }
}
