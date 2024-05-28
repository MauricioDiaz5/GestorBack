using GestorBackApi.Implement;
using GestorBackApi.Interface;
using GestorBackApi.Model;

namespace GestorBackApi.Service
{
    public class UsuarioService : IUsuario
    {
        private readonly UsuarioImplement usuarioImplement;

        public UsuarioService() 
        { 
            usuarioImplement = new UsuarioImplement();
        }

        public RespuestaGenerica AltaUsuario(UsuarioModel request)
        {
            return usuarioImplement.AltaUsuarioBD(request);
        }

        public RespuestaGenerica Session(SessionRequest request)
        {
            RespuestaGenerica respuesta = usuarioImplement.ValidaSessionBD(request);
            UsuarioModel usuario = (UsuarioModel)respuesta.Datos;
            if(respuesta.Codigo == 1 && !string.IsNullOrEmpty(usuario.IdUsuario))
            {
                return respuesta;
            }
            else
            {
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Usuario o Contraseña no valido";
                respuesta.Datos = string.Empty;
                return respuesta;
            }
        }

        public RespuestaGenerica UsuarioValido(string usuario)
        {
            return usuarioImplement.ValidaUsuarioBD(usuario);
        }
    }
}
