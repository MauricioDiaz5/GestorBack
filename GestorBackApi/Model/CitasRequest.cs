namespace GestorBackApi.Model
{
    public class CitasRequest
    {
        public CitasRequest() 
        {
            Operacion = 0;
            IdCita = 0;
            IdPaciente = null;
            Doctor = null;
            IdArea = 0;
            Signos = null;
            Motivos = null;
            TratamientoActual = null;
            Alergico = null;
            Receta = null;
            Atendida = 0;
            Comentarios = null;
            FechaCita = null;
        }

        public int Operacion { get; set; }
        public int IdCita { get; set; }
        public string? IdPaciente { get; set; }
        public string? Doctor { get; set; }
        public int IdArea { get; set; }
        public string? Signos { get; set; }
        public string? Motivos { get; set; }
        public string? TratamientoActual { get; set; }
        public string? Alergico { get; set; }
        public string? Receta { get; set; }
        public int Atendida { get; set; }
        public string? Comentarios { get; set; }
        public string? FechaCita { get; set; }
    }
}
