using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("CONFIGURACION_COMERCIO_G4")]
    public class ConfiguracionComercio
    {
        [Key]
        public int IdConfiguracion { get; set; }

        [Required]
        public int IdComercio { get; set; }

        // 🔥 FIX IMPORTANTE: evita que EF invente columnas
        [ForeignKey(nameof(IdComercio))]
        public Comercio? Comercio { get; set; }

        [Required]
        public int TipoConfiguracion { get; set; }

        [Required]
        public int Comision { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        public bool Estado { get; set; } = true;
    }
}
