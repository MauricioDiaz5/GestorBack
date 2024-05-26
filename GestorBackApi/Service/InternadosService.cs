using GestorBackApi.Implement;
using GestorBackApi.Interface;
using GestorBackApi.Model;

namespace GestorBackApi.Service
{
    public class InternadosService : IInternados
    {
        private readonly InternadosImplement internadosImplement;

        public InternadosService() 
        {
            internadosImplement = new InternadosImplement();
        }

        public RespuestaGenerica Internados(InternadosRequest request)
        {
            return internadosImplement.InternadosBD(request);
        }
    }
}
