using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IConfiguracionRepository
    {
        List<ConfiguracionComercio> GetAll();
        ConfiguracionComercio GetByComercio(int idComercio);
        void Add(ConfiguracionComercio config);
        void Update(ConfiguracionComercio config);
        bool ExisteConfiguracion(int idComercio);
    }
}
