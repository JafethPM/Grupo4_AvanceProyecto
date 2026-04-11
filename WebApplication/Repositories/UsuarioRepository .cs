using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Obtener(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public bool Insertar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            return _context.SaveChanges() > 0;
        }

        public bool Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return _context.SaveChanges() > 0;
        }

        public bool ExisteIdentificacion(string identificacion)
        {
            return _context.Usuarios.Any(x => x.Identificacion == identificacion);
        }
    }
}
