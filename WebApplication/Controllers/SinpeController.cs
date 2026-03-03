using Microsoft.AspNetCore.Mvc;
using WebApplication.Bussines;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class SinpeController : Controller
    {
        private readonly SinpeBussines _bussines;

        public SinpeController(SinpeBussines bussines)
        {
            _bussines = bussines;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Sinpe sinpe)
        {
            if (!ModelState.IsValid)
                return View(sinpe);

            try
            {
                _bussines.Registrar(sinpe);
                return RedirectToAction("Registrar");
            }
            catch
            {
                ModelState.AddModelError("", "Error al registrar SINPE");
                return View(sinpe);
            }
        }
    }
}
