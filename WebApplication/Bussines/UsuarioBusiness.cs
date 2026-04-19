using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioRepository _repo;
        private readonly IBitacoraService _bitacora;

        public UsuarioBusiness(IUsuarioRepository repo, IBitacoraService bitacora  )
        {
            _repo = repo;
            _bitacora = bitacora;
        }

        public List<Usuario> Listar() => _repo.Listar();

        public Usuario Obtener(int id) => _repo.Obtener(id);

        public string Insertar(Usuario u)
        {
            if (_repo.ExisteIdentificacion(u.Identificacion))
                return "Ya existe un usuario con esta identificación";

            u.FechaDeRegistro = DateTime.Now;
            u.Estado = true;

            _repo.Insertar(u);
            _bitacora.RegistrarEvento
                        (
                            "Usuario_G4",
                            "INSERT",
                            "Se registró un nuevo usuario",
                            null,
                            u
                        );
            return "OK";

        }

        public string Actualizar(Usuario u)
        {
            var existente = _repo.Obtener(u.IdUsuario);

            if (existente == null)
                return "No existe";

            existente.Nombres = u.Nombres;
            existente.PrimerApellido = u.PrimerApellido;
            existente.SegundoApellido = u.SegundoApellido;
            existente.Identificacion = u.Identificacion;
            existente.CorreoElectronico = u.CorreoElectronico;
            existente.Estado = u.Estado;
            existente.FechaDeModificacion = DateTime.Now;

            _repo.Actualizar(existente);
                _bitacora.RegistrarEvento
                        (
                            "Usuario_G4",
                            "UPDATE",
                            "Se editó un usuario",
                            null,
                            existente
                        );
            return "OK";
        }
    }
}
