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
            return usuarioImplement.ValidaSessionBD(request);
        }

        public RespuestaGenerica UsuarioValido(string usuario)
        {
            return usuarioImplement.ValidaUsuarioBD(usuario);
        }
    }
}
