using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Sinpe
    {
        [Key]
        public int IdSinpe { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoOrigen { get; set; }

        [Required]
        public string NombreOrigen { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoDestinatario { get; set; }

        [Required]
        public string NombreDestinatario { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
