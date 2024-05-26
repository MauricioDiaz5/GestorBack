using GestorBackApi.Interface;
using GestorBackApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(SessionRequest request)
        {
            RespuestaGenerica respuesta = _usuario.Session(request);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("validaUsuario")]
        public IActionResult Login(string usuario)
        {
            RespuestaGenerica respuesta = _usuario.UsuarioValido(usuario);
            return Ok(respuesta);
        }
    }
}
