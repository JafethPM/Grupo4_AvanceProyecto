using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Business
{
    public class ConfiguracionComercioBusiness
    {
        private readonly IConfiguracionComercioRepository _repo;
        private readonly IBitacoraService _bitacora;

        public ConfiguracionComercioBusiness(IConfiguracionComercioRepository repo, IBitacoraService bitacora)
        {
            _repo = repo;
            _bitacora = bitacora;
        }

        public List<ConfiguracionComercio> Listar()
        {
            return _repo.Listar();
        }

        public ConfiguracionComercio Obtener(int id)
        {
            return _repo.Obtener(id);
        }

        public string Insertar(ConfiguracionComercio c)
        {
            if (_repo.ExistePorComercio(c.IdComercio))
                return "Este comercio ya tiene configuración";

            c.FechaDeRegistro = DateTime.Now;
            c.Estado = true;

            _repo.Insertar(c);
            _bitacora.RegistrarEvento
                    (
                        "ConfiguracionComercio_G4",
                        "INSERT",
                        "Se registró una nueva configuración de comercio",
                        null,
                        c
                    );
            return "OK";

        }

        public string Actualizar(ConfiguracionComercio c)
        {
            var existente = _repo.Obtener(c.IdConfiguracion);

            if (existente == null)
                return "No existe";

            existente.TipoConfiguracion = c.TipoConfiguracion;
            existente.Comision = c.Comision;
            existente.Estado = c.Estado;
            existente.FechaDeModificacion = DateTime.Now;

            _repo.Actualizar(existente);
            _bitacora.RegistrarEvento
                    (
                        "ConfiguracionComercio_G4",
                        "UPDATE",
                        "Se actualizó una configuración de comercio",
                        null,
                        existente
                    );
            return "OK";    
        }
    }
}
