using GestorBackApi.Implement;
using GestorBackApi.Interface;
using GestorBackApi.Model;

namespace GestorBackApi.Service
{
    public class CatalogoService : ICatalogo
    {
        private readonly CatalogoImplement catalogoImplement;

        public CatalogoService() 
        {
            catalogoImplement = new CatalogoImplement();
        }

        public RespuestaGenerica getCatalogos(int idCatalogo)
        {
            return catalogoImplement.GetCatalogo(idCatalogo);
        }
    }
}
