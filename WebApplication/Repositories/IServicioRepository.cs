using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IServicioRepository
    {
        List<Servicio> Listar();
        Servicio Obtener(int id);
        void Insertar(Servicio s);
        void Actualizar(Servicio s);
    }
}
