using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly AppDbContext _context;

        public CitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cita> Listar()
        {
            return _context.Citas
                .Include(x => x.Servicio)
                .ToList();
        }

        public Cita Obtener(int id)
        {
            return _context.Citas
                .Include(x => x.Servicio)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insertar(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }
    }
}
