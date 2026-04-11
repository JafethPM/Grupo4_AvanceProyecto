using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IReporteRepository
    {
        List<ReporteMensual> GetAll();
        void GenerarReportes();
    }
}
