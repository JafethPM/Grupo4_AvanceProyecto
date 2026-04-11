using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinpeApiController : ControllerBase
    {
        private readonly SinpeBusiness _business;

        public SinpeApiController(SinpeBusiness business)
        {
            _business = business;
        }

        // 🔹 POST: api/sinpe
        [HttpPost]
        public IActionResult Create([FromBody] Sinpe sinpe)
        {
            try
            {
                _business.Create(sinpe);
                return Ok(new
                {
                    mensaje = "SINPE registrado correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // 🔹 GET: api/sinpe
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _business.ObtenerTodos(); // ← IMPORTANTE
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
    }
}