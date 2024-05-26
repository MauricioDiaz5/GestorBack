namespace GestorBackApi.Model
{
    public class RespuestaGenerica
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public dynamic Datos { get; set; }
    }
}
