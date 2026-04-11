using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ConfiguracionComercioController : Controller
    {
        private readonly ConfiguracionComercioBusiness _business;

        public ConfiguracionComercioController(ConfiguracionComercioBusiness business)
        {
            _business = business;
        }

        public IActionResult Index()
        {
            var lista = _business.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ConfiguracionComercio c)
        {
            if (!ModelState.IsValid)
                return View(c);

            var result = _business.Insertar(c);

            if (result != "OK")
            {
                ViewBag.Error = result;
                return View(c);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _business.Obtener(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ConfiguracionComercio c)
        {
            var result = _business.Actualizar(c);

            if (result != "OK")
            {
                ViewBag.Error = result;
                return View(c);
            }

            return RedirectToAction("Index");
        }
    }
}
