using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class ConfiguracionComercioRepository : IConfiguracionComercioRepository
    {
        private readonly AppDbContext _context;

        public ConfiguracionComercioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ConfiguracionComercio> Listar()
        {
            return _context.ConfiguracionComercio.ToList();
        }

        public ConfiguracionComercio Obtener(int id)
        {
            return _context.ConfiguracionComercio.FirstOrDefault(x => x.IdConfiguracion == id);
        }

        public void Insertar(ConfiguracionComercio c)
        {
            _context.ConfiguracionComercio.Add(c);
            _context.SaveChanges();
        }

        public void Actualizar(ConfiguracionComercio c)
        {
            _context.ConfiguracionComercio.Update(c);
            _context.SaveChanges();
        }

        public bool ExistePorComercio(int idComercio)
        {
            return _context.ConfiguracionComercio.Any(x => x.IdComercio == idComercio);
        }
    }
}
