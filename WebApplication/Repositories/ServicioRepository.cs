using WebApplicationAPP.Data;
using WebApplicationAPP.Models;


namespace WebApplicationAPP.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Servicio> Listar()
        {
            return _context.Servicios.ToList();
        }

        public Servicio Obtener(int id)
        {
            return _context.Servicios.Find(id);
        }

        public void Insertar(Servicio s)
        {
            _context.Servicios.Add(s);
            _context.SaveChanges();
        }

        public void Actualizar(Servicio s)
        {
            _context.Servicios.Update(s);
            _context.SaveChanges();
        }
    }
}
