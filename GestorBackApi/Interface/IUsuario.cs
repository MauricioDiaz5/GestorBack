using GestorBackApi.Model;

namespace GestorBackApi.Interface
{
    public interface IUsuario
    {
        RespuestaGenerica Session(SessionRequest request);
        RespuestaGenerica UsuarioValido(string usuario);
        RespuestaGenerica AltaUsuario(UsuarioModel request);
    }
}
