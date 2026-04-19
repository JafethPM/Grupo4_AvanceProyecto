using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Bussines;

namespace WebApplicationAPP.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {
        private readonly ReporteBusiness _business;

        public ReporteController(ReporteBusiness business)
        {
            _business = business;
        }

        public IActionResult Index()
        {
            var data = _business.GetAll();
            return View(data);
        }

        public IActionResult Generar()
        {
            _business.Generar();
            return RedirectToAction("Index");
        }
    }
}
