using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("REPORTE_MENSUAL_G4")]
    public class ReporteMensual
    {
        [Key]
        public int IdReporte { get; set; }

        public int IdComercio { get; set; }

        public int CantidadDeCajas { get; set; }

        public decimal MontoTotalRecaudado { get; set; }

        public int CantidadDeSINPES { get; set; }

        public decimal MontoTotalComision { get; set; }

        public DateTime FechaDelReporte { get; set; }

        [NotMapped]
        public string NombreComercio { get; set; }
    }
}
