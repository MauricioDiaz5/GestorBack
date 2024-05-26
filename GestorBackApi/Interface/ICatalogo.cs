using GestorBackApi.Model;

namespace GestorBackApi.Interface
{
    public interface ICatalogo
    {
        RespuestaGenerica getCatalogos(int idCatalogo);
    }
}
