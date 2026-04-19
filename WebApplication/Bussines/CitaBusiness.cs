using WebApplicationAPP.Data;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Business
{
    public class CitaBusiness
    {
        private readonly ICitaRepository _repo;
        private readonly IBitacoraService _bitacora;

        public CitaBusiness(ICitaRepository repo, IBitacoraService bitacora)
        {
            _repo = repo;
            _bitacora = bitacora;
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
            _bitacora.RegistrarEvento
                    (
                        "Citas_G4",
                        "INSERT",
                        "Se reservó una nueva cita",
                        null,
                        cita
                    );
        }
    }
}
