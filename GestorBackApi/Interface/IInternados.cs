using GestorBackApi.Model;

namespace GestorBackApi.Interface
{
    public interface IInternados
    {
        RespuestaGenerica Internados(InternadosRequest request);
    }
}
