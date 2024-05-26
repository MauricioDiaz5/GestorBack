using GestorBackApi.Model;
using GestorBackApi.Util;
using System.Data;
using System.Data.SqlClient;

namespace GestorBackApi.Implement
{
    public class InternadosImplement : ConexionBD
    {
        private readonly SqlCommand cmd;
        private readonly SqlConnection conn;

        public InternadosImplement() 
        {
            cmd = new SqlCommand();
            conn = new SqlConnection();
            cmd = GetCommand();
            conn = GetConnection();
        }

        public RespuestaGenerica InternadosBD(InternadosRequest internado)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            List<InternadosRequest> listaInternados = new List<InternadosRequest>();
            //se define el nombre del sp
            cmd.CommandText = "SP_INTERNADO";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@OP", internado.Operacion);
                cmd.Parameters.AddWithValue("@IDINTERNADO", internado.IdInternado);
                cmd.Parameters.AddWithValue("@PACIENTE", internado.IdPaciente);
                cmd.Parameters.AddWithValue("@DOCTOR", internado.Doctor);
                cmd.Parameters.AddWithValue("@AREA", internado.IdArea);
                cmd.Parameters.AddWithValue("@STATUS", internado.IdEstatus);
                cmd.Parameters.AddWithValue("@MOTIVO", internado.Motivo);
                cmd.Parameters.AddWithValue("@FECHAINGRESO", internado.FechaIngreso);
                cmd.Parameters.AddWithValue("@FECHASALIDA", internado.FechaSalida);
                //se definen parametros de salida del SP
                cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                //se abre la conexion con la base de datos
                conn.Open();
                //se ejecuta el sp 
                int i = cmd.ExecuteNonQuery();
                //recuperacion de codigo, mensaje y datos retornados por el sp
                respuesta.Codigo = Convert.ToInt32(cmd.Parameters["@CODIGO"].Value);
                respuesta.Mensaje = Convert.ToString(cmd.Parameters["@MENSAJE"].Value);
                switch (internado.Operacion)
                {
                    case 0:
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            listaInternados.Add(new InternadosRequest
                            {
                                IdInternado = (int)dataReader["idRegistro"],
                                IdPaciente = (string)dataReader["idPaciente"],
                                Doctor = (string)dataReader["idUsuarioAtiende"],
                                IdArea = (int)dataReader["idArea"],
                                IdEstatus = (int)dataReader["statusAtendido"],
                                Motivo = (string)dataReader["motivo"],
                                FechaIngreso = (string)dataReader["fechaIngreso"],
                                FechaSalida = (string)dataReader["fechaSalida"]
                            });
                        }
                        respuesta.Datos = listaInternados;
                        break;
                    case 2:
                        SqlDataReader dataReader2 = cmd.ExecuteReader();
                        while (dataReader2.Read())
                        {
                            listaInternados.Add(new InternadosRequest
                            {
                                IdInternado = (int)dataReader2["idRegistro"],
                                IdPaciente = (string)dataReader2["idPaciente"],
                                Doctor = (string)dataReader2["idUsuarioAtiende"],
                                IdArea = (int)dataReader2["idArea"],
                                IdEstatus = (int)dataReader2["statusAtendido"],
                                Motivo = (string)dataReader2["motivo"],
                                FechaIngreso = (string)dataReader2["fechaIngreso"],
                                FechaSalida = (string)dataReader2["fechaSalida"]
                            });
                        }
                        respuesta.Datos = listaInternados;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}
