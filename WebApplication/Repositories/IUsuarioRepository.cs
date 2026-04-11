using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario Obtener(int id);
        bool Insertar(Usuario usuario);
        bool Actualizar(Usuario usuario);
        bool ExisteIdentificacion(string identificacion);
    }
}
