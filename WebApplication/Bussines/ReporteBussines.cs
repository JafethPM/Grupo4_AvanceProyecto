using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Bussines
{
    public class ReporteBusiness 

    {

        private readonly IReporteRepository _repo;
        private readonly IBitacoraService _bitacora;

        public ReporteBusiness(IReporteRepository repo, IBitacoraService bitacora)
        {
            _repo = repo;
            _bitacora = bitacora;   
        }

        public List<ReporteMensual> GetAll()
        {
            return _repo.GetAll();
        }

        public void Generar()
        {
            _repo.GenerarReportes();
                _bitacora.RegistrarEvento
                        (
                            "Reporte_G4",
                            "GENERATE",
                            "Se generaron los reportes mensuales",
                            null,
                            null
                        );
        }
    }
}
