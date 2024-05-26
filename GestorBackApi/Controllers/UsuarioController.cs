using GestorBackApi.Interface;
using GestorBackApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestorBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario) 
        {
            _usuario = usuario;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] SessionRequest request)
        {
            RespuestaGenerica respuesta = _usuario.Session(request);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("validaUsuario")]
        public IActionResult Login([FromQuery][Required] string usuario)
        {
            RespuestaGenerica respuesta = _usuario.UsuarioValido(usuario);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("registro")]
        public IActionResult AltaUsuario([FromBody] UsuarioModel request)
        {
            RespuestaGenerica respuesta = _usuario.AltaUsuario(request);
            return Ok(respuesta);
        }
    }
}
