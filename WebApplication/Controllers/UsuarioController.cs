using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBusiness _business;

        public UsuarioController(UsuarioBusiness business)
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
        public IActionResult Create(Usuario u)
        {
            var result = _business.Insertar(u);

            if (result != "OK")
            {
                ViewBag.Error = result;
                return View(u);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_business.Obtener(id));
        }

        [HttpPost]
        public IActionResult Edit(Usuario u)
        {
            var result = _business.Actualizar(u);

            if (result != "OK")
            {
                ViewBag.Error = result;
                return View(u);
            }

            return RedirectToAction("Index");
        }
    }
}
