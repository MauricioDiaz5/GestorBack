namespace GestorBackApi.Model
{
    public class UsuarioModel
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public string FechaAlta { get; set; }
        public int Activo { get; set; }
        public int IdArea { get; set; }
    }
}
