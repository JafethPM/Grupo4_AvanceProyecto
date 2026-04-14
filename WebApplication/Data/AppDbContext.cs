using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Cajas> Cajas { get; set; }

        public DbSet<Sinpe> Sinpe { get; set; }

        public DbSet<Comercio> Comercio { get; set; }

        public DbSet<ReporteMensual> ReporteMensual { get; set; }

        public DbSet<BitacoraEvento> BitacoraEvento { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }

        public DbSet<ConfiguracionComercio> ConfiguracionComercio { get; set; }
    }
}
