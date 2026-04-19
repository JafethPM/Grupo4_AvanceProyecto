using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;   


namespace WebApplicationAPP.Bussines
{
    public class ComercioBussines
    {
        private readonly IComercioRepository _repo;
        private readonly IBitacoraService _bitacora;

        public ComercioBussines(IComercioRepository repo, IBitacoraService bitacora)
        {
            _repo = repo;
            _bitacora = bitacora;

        }

        public List<Comercio> Listar()
        {
            return _repo.ObtenerTodos();
        }


        public void Registrar(Comercio comercio)
        {

            var existe = _repo.ObtenerTodos()
                              .Any(x => x.Identificacion == comercio.Identificacion);

            if (existe)
            {
                throw new Exception("Ya existe un comercio con esa identificación.");
            }

            comercio.FechaDeRegistro = DateTime.Now;
            comercio.Estado = true;

            _repo.Agregar(comercio);
            _bitacora.RegistrarEvento
                    (
                        "Comercio_G4",
                        "INSERT",
                        "Se registró un nuevo comercio",
                        null,
                        comercio
                    );
        }


        public void Editar(Comercio comercio)
        {
            var comercioBD = _repo.ObtenerPorId(comercio.IdComercio);

            if (comercioBD == null)
                throw new Exception("El comercio no existe.");


            comercioBD.Nombre = comercio.Nombre;
            comercioBD.TipoDeComercio = comercio.TipoDeComercio;
            comercioBD.Telefono = comercio.Telefono;
            comercioBD.CorreoElectronico = comercio.CorreoElectronico;
            comercioBD.Direccion = comercio.Direccion;
            comercioBD.Estado = comercio.Estado;
            comercioBD.FechaDeModificacion = DateTime.Now;

            _repo.Actualizar(comercioBD);
            _bitacora.RegistrarEvento
                        (
                            "Comercio_G4",
                            "UPDATE",
                            "Se editó un comercio",
                            null,
                            comercioBD
                        );
        }


        public Comercio Obtener(int id)
        {
            return _repo.ObtenerPorId(id);
        }
    }
}
