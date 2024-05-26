using GestorBackApi.Interface;
using GestorBackApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestorBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogo _catalogo;

        public CatalogoController(ICatalogo catalogo)
        {
            _catalogo = catalogo;
        }

        [HttpGet]
        [Route("catalogos")]
        public IActionResult GetCatalogo([FromQuery] [Required] int idCatalogo)
        {
            RespuestaGenerica respuesta = _catalogo.getCatalogos(idCatalogo);
            return Ok(respuesta);

        }
    }
}
