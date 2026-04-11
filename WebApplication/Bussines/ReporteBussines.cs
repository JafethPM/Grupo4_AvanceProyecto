using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Bussines
{
    public class ReporteBusiness
    {
        private readonly IReporteRepository _repo;

        public ReporteBusiness(IReporteRepository repo)
        {
            _repo = repo;
        }

        public List<ReporteMensual> GetAll()
        {
            return _repo.GetAll();
        }

        public void Generar()
        {
            _repo.GenerarReportes();
        }
    }
}
