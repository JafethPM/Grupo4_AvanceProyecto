using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;
using System.Text.Json;

namespace WebApplicationAPP.Bussines
{
    public class CajaBussiness
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly IBitacoraService _bitacora;

        public CajaBussiness(ICajaRepository cajaRepository, IBitacoraService bitacora)
        {
            _cajaRepository = cajaRepository;
            _bitacora = bitacora;
        }

        public List<Cajas> GetAllCajas()
        {
            return _cajaRepository.GetAllCajas();
        }

        public Cajas GetCajaById(int id)
        {
            return _cajaRepository.GetCajaById(id);
        }

        public void AddCaja(Cajas caja)
        {
            caja.IdComercio = 3;

            if (_cajaRepository.ExisteNombreCaja(caja.Nombre, caja.IdComercio, caja.Id))
            {
                throw new Exception("Ya existe otra caja con ese nombre.");
            }


            if (caja.Estado && _cajaRepository.ExisteTelefonoActivo(caja.TelefonoSINPE, caja.IdComercio))
            {
                throw new Exception("Ese teléfono SINPE ya está asignado a otra caja activa.");
            }

            caja.FechaDeRegistro = DateTime.Now;
            caja.FechaDeModificacion = DateTime.Now;

            _cajaRepository.AddCaja(caja);
            _bitacora.RegistrarEvento
                (
                   "Cajas_G4",
                   "INSERT",
                   "Se creó una nueva caja",
                   null,
                   caja
                );

        }


        public void UpdateCaja(Cajas caja)
        {
            var existente = _cajaRepository.GetCajaById(caja.Id);

            if (existente == null)
                throw new Exception("La caja no existe.");


            if (_cajaRepository.ExisteNombreCaja(caja.Nombre, caja.IdComercio, caja.Id))
            {
                throw new Exception("Ya existe otra caja con ese nombre.");
            }


            if (caja.Estado &&
                _cajaRepository.ExisteTelefonoActivo(
                    caja.TelefonoSINPE,
                    caja.IdComercio,
                    caja.Id))
            {
                throw new Exception("Ese teléfono SINPE ya está asignado a otra caja.");
            }

            existente.Nombre = caja.Nombre;
            existente.Descripcion = caja.Descripcion;
            existente.TelefonoSINPE = caja.TelefonoSINPE;
            existente.Estado = caja.Estado;
            existente.FechaDeModificacion = DateTime.Now;

            _cajaRepository.UpdateCaja();

            _bitacora.RegistrarEvento
                (
                    "Cajas_G4",
                    "UPDATE",
                    "Se actualizo la informacion",
                    null,
                    caja
                );
        }


        public void DeleteCaja(int id)
        {
            var caja = _cajaRepository.GetCajaById(id);

            if (caja == null)
                throw new Exception("La caja no existe.");

            _cajaRepository.DeleteCaja(id);

            // BITÁCORA DELETE
            _bitacora.RegistrarEvento(
                "Cajas_G4",
                "DELETE",
                "Se eliminó una caja",
                JsonSerializer.Serialize(caja),
                null
            );
        }
    }
}
