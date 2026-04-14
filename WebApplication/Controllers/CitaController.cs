using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class CitaController : Controller
    {
        private readonly CitaBusiness _business;
        private readonly AppDbContext _context;

        public CitaController(CitaBusiness business, AppDbContext context)
        {
            _business = business;
            _context = context;
        }

        // LISTA SERVICIOS
        public IActionResult Index()
        {
            var servicios = _context.Servicios
                .Where(x => x.Estado == true)
                .ToList();

            return View(servicios);
        }

        // FORM RESERVA
        public IActionResult Reservar(int id)
        {
            var servicio = _context.Servicios.Find(id);

            if (servicio == null)
                return RedirectToAction("Index");

            ViewBag.Servicio = servicio;

            return View(new Cita { IdServicio = id });
        }

        [HttpPost]
        public IActionResult Reservar(Cita cita)
        {
            var servicio = _context.Servicios.Find(cita.IdServicio);

            if (servicio == null)
            {
                ViewBag.Error = "Servicio no encontrado";
                return View(cita);
            }

            _business.Reservar(cita, servicio.Monto, servicio.IVA);

            return RedirectToAction("Detalle", new { id = cita.Id });
        }

        // DETALLE
        public IActionResult Detalle(int id)
        {
            var cita = _business.Obtener(id);

            if (cita == null)
                return RedirectToAction("Index");

            return View(cita);
        }

        // AJAX
        public IActionResult Buscar(int id)
        {
            var cita = _business.Obtener(id);

            if (cita == null)
                return Json(null);

            return PartialView("_DetalleCita", cita);
        }
    }
}
