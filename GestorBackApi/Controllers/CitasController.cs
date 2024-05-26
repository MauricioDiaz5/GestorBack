using GestorBackApi.Interface;
using GestorBackApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestorBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitas _citas;

        public CitasController(ICitas citas)
        {
            _citas = citas;
        }

        [HttpPost]
        [Route("cita")]
        public IActionResult Login([FromBody] CitasRequest request)
        {
            RespuestaGenerica respuesta = _citas.Citas(request);
            return Ok(respuesta);
        }
    }
}
