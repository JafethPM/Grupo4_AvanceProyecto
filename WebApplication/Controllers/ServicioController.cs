using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServicioBusiness _business;

        public ServicioController(ServicioBusiness business)
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
        public IActionResult Create(Servicio s)
        {
            _business.Crear(s);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _business.Obtener(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Servicio s)
        {
            _business.Editar(s);
            return RedirectToAction("Index");
        }
    }
}
