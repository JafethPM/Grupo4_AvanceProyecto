using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Business
{
    public class CitaBusiness
    {
        private readonly ICitaRepository _repo;

        public CitaBusiness(ICitaRepository repo)
        {
            _repo = repo;
        }

        public List<Cita> Listar()
        {
            return _repo.Listar();
        }

        public Cita Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public void Reservar(Cita cita, decimal monto, decimal iva)
        {
            cita.MontoTotal = monto + (monto * iva);
            cita.FechaDeRegistro = DateTime.Now;

            _repo.Insertar(cita);
        }
    }
}
