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

        public RespuestaGenerica Session(SessionRequest request)
        {
            return usuarioImplement.ValidaSession(request);
        }

        public RespuestaGenerica UsuarioValido(string usuario)
        {
            return usuarioImplement.ValidaUsuario(usuario);
        }
    }
}
