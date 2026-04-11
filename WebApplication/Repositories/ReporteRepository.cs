using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly AppDbContext _context;

        public ReporteRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ReporteMensual> GetAll()
        {
            var reportes = (from r in _context.ReporteMensual
                            join c in _context.Comercio on r.IdComercio equals c.IdComercio
                            select new ReporteMensual
                            {
                                IdReporte = r.IdReporte,
                                IdComercio = r.IdComercio,
                                NombreComercio = c.Nombre,
                                CantidadDeCajas = r.CantidadDeCajas,
                                MontoTotalRecaudado = r.MontoTotalRecaudado,
                                CantidadDeSINPES = r.CantidadDeSINPES,
                                MontoTotalComision = r.MontoTotalComision,
                                FechaDelReporte = r.FechaDelReporte
                            }).ToList();

            return reportes;
        }

        public void GenerarReportes()
        {
            var comercios = _context.Comercio.ToList();

            foreach (var comercio in comercios)
            {
                var cajas = _context.Cajas
                    .Where(c => c.IdComercio == comercio.IdComercio)
                    .ToList();

                int cantidadCajas = cajas.Count;

                var telefonos = cajas.Select(c => c.TelefonoSINPE).ToList();

                var sinpes = _context.Sinpe
                    .Where(s => telefonos.Contains(s.TelefonoDestinatario)
                             && s.FechaDeRegistro.Month == DateTime.Now.Month
                             && s.FechaDeRegistro.Year == DateTime.Now.Year)
                    .ToList();

                int cantidadSinpes = sinpes.Count;
                decimal montoTotal = sinpes.Sum(s => s.Monto);

                int comisionConfig = 10; 
                decimal porcentaje = comisionConfig / 100m;

                decimal montoComision = montoTotal * porcentaje;

                var existente = _context.ReporteMensual.FirstOrDefault(r =>
                    r.IdComercio == comercio.IdComercio &&
                    r.FechaDelReporte.Month == DateTime.Now.Month &&
                    r.FechaDelReporte.Year == DateTime.Now.Year
                );

                if (existente != null)
                {
                    existente.CantidadDeCajas = cantidadCajas;
                    existente.CantidadDeSINPES = cantidadSinpes;
                    existente.MontoTotalRecaudado = montoTotal;
                    existente.MontoTotalComision = montoComision;
                }
                else
                {
                    _context.ReporteMensual.Add(new ReporteMensual
                    {
                        IdComercio = comercio.IdComercio,
                        CantidadDeCajas = cantidadCajas,
                        CantidadDeSINPES = cantidadSinpes,
                        MontoTotalRecaudado = montoTotal,
                        MontoTotalComision = montoComision,
                        FechaDelReporte = DateTime.Now
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
