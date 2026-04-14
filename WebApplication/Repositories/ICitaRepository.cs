using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface ICitaRepository
    {
        List<Cita> Listar();
        Cita Obtener(int id);
        void Insertar(Cita cita);
    }
}
