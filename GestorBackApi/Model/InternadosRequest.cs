namespace GestorBackApi.Model
{
    public class InternadosRequest
    {
        public InternadosRequest() 
        {
            Operacion = 0;
            IdInternado = 0;
            IdPaciente = null;
            Doctor = null;
            IdArea = 0;
            IdEstatus = 0;
            Motivo = null;
            FechaIngreso = null;
            FechaSalida = null;

        }

        public int Operacion { get; set; }
        public int IdInternado { get; set; }
        public string? IdPaciente { get; set;}
        public string? Doctor { get; set; }
        public int IdArea { get; set; }
        public int IdEstatus { get; set; }
        public string? Motivo { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaSalida { get; set; }


    }
}
