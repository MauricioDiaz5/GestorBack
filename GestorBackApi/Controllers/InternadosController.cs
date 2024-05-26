using GestorBackApi.Interface;
using GestorBackApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestorBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternadosController : ControllerBase
    {
        private readonly IInternados _internados;

        public InternadosController(IInternados internados)
        {
            _internados = internados;
        }

        [HttpPost]
        [Route("internado")]
        public IActionResult AltaInternados([FromBody] InternadosRequest request)
        {
            RespuestaGenerica respuesta = _internados.Internados(request);
            return Ok(respuesta);
        }
    }
}
