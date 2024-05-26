using GestorBackApi.Implement;
using GestorBackApi.Interface;
using GestorBackApi.Model;

namespace GestorBackApi.Service
{
    public class CitasService : ICitas
    {
        private readonly CitasImplement citasImplement;

        public CitasService() 
        {
            citasImplement = new CitasImplement();
        }
        public RespuestaGenerica Citas(CitasRequest request)
        {
            return citasImplement.AltaCitaBD(request);
        }
    }
}
