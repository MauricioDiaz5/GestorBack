using System.Data;
using System.Data.SqlClient;

namespace GestorBackApi.Util
{
    public class ConexionBD
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public ConexionBD()
        {
            conn = new SqlConnection();
            cmd = new SqlCommand();
            //variable para leer el archivo de configuracion appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //se obtiene el valor del objeto ConnectionStrings y se obtiene el valor del atributo SQL que es la cadena de conexion de la base
            conn.ConnectionString = builder.GetSection("ConnectionStrings:SQL").Value;
            //se definen los datos de conexion con la base
            cmd.Connection = conn;
            //definicion para ejecutar SP
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public SqlCommand GetCommand()
        {   
            return cmd;
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
