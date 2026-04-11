using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioBusiness(IUsuarioRepository repo)
        {
            _repo = repo;
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
            return "OK";
        }
    }
}
