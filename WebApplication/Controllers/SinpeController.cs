using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class SinpeController : Controller
    {
        private readonly SinpeBusiness _bussines;

        public SinpeController(SinpeBusiness bussines)
        {
            _bussines = bussines;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sinpe sinpe)
        {
            if (!ModelState.IsValid)
                return View(sinpe);

            try
            {
                _bussines.Create(sinpe);
                return RedirectToAction("Create");
            }
            catch
            {
                ModelState.AddModelError("", "Error al registrar SINPE");
                return View(sinpe);
            }
        }
    }
}
