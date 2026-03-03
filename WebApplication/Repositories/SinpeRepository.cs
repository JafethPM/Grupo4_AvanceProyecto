using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class SinpeRepository : ISinpeRepository
    {
        private readonly AppDbContext _context;

        public SinpeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Registrar(Sinpe sinpe)
        {
            _context.Sinpes.Add(sinpe);
            _context.SaveChanges();
        }
    }
}
