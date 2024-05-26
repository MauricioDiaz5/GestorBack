using GestorBackApi.Model;

namespace GestorBackApi.Interface
{
    public interface ICitas
    {
        RespuestaGenerica Citas(CitasRequest request);
    }
}
