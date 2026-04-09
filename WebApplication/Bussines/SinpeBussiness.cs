using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Business
{
    public class SinpeBusiness
    {
        private readonly ISinpeRepository _sinpeRepo;
        private readonly ICajaRepository _cajasRepo;
        private readonly IBitacoraService _bitacora;

        public SinpeBusiness(
            ISinpeRepository sinpeRepo,
            ICajaRepository cajasRepo,
            IBitacoraService bitacora)
        {
            _sinpeRepo = sinpeRepo;
            _cajasRepo = cajasRepo;
            _bitacora = bitacora;
        }

       
        public List<Sinpe> GetAll()
        {
            return _sinpeRepo.ObtenerTodos();
        }


        public void Create(Sinpe sinpe)
        {
            var caja = _cajasRepo.GetAllCajas()
                .FirstOrDefault(c => c.TelefonoSINPE == sinpe.TelefonoDestinatario);

            if (caja == null)
                throw new Exception("El teléfono destinatario no está registrado.");

            if (!caja.Estado)
                throw new Exception("No se puede pagar a una caja inactiva.");

            sinpe.FechaDeRegistro = DateTime.Now;
            sinpe.Estado = false;

            _sinpeRepo.Create(sinpe);

            _bitacora.RegistrarEvento(
                "SINPE",
                "Registrar",
                "Pago SINPE registrado",
                "",
                null,
                sinpe
            );
        }
    }
}
