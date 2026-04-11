using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IConfiguracionComercioRepository
    {
        List<ConfiguracionComercio> Listar();
        ConfiguracionComercio Obtener(int id);
        void Insertar(ConfiguracionComercio c);
        void Actualizar(ConfiguracionComercio c);
        bool ExistePorComercio(int idComercio);
    }
}
