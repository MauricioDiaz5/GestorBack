using GestorBackApi.Model;
using GestorBackApi.Util;
using System.Data;
using System.Data.SqlClient;

namespace GestorBackApi.Implement
{
    public class CitasImplement : ConexionBD
    {
        private readonly SqlCommand cmd;
        private readonly SqlConnection conn;

        public CitasImplement() 
        {
            cmd = new SqlCommand();
            conn = new SqlConnection();
            cmd = GetCommand();
            conn = GetConnection();
        }

        public RespuestaGenerica AltaCitaBD(CitasRequest cita)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            List<CitasRequest> listaCitas = new List<CitasRequest>();
            //se define el nombre del sp
            cmd.CommandText = "SP_CITA";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@OP", cita.Operacion);
                cmd.Parameters.AddWithValue("@IDCITA", cita.IdCita);
                cmd.Parameters.AddWithValue("@PACIENTE", cita.IdPaciente);
                cmd.Parameters.AddWithValue("@DOCTOR", cita.Doctor);
                cmd.Parameters.AddWithValue("@AREA", cita.IdArea);
                cmd.Parameters.AddWithValue("@SIGNOS", cita.Signos);
                cmd.Parameters.AddWithValue("@MOTIVOS", cita.Motivos);
                cmd.Parameters.AddWithValue("@TRATAMIENTOACT", cita.TratamientoActual);
                cmd.Parameters.AddWithValue("@ALERGICO", cita.Alergico);
                cmd.Parameters.AddWithValue("@RECETA", cita.Receta);
                cmd.Parameters.AddWithValue("@ATENDIDA", cita.Atendida);
                cmd.Parameters.AddWithValue("@COMENTARIOS", cita.Comentarios);
                cmd.Parameters.AddWithValue("@FECHACITA", cita.FechaCita);
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
                switch (cita.Operacion) 
                { 
                    case 0:
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            listaCitas.Add(new CitasRequest()
                            {
                                IdCita = (int)dataReader["idCita"],
                                IdPaciente = (string)dataReader["idPaciente"],
                                Doctor = (string)dataReader["usuario_atiende"],
                                IdArea = (int)dataReader["idArea"],
                                Signos = (string)dataReader["signos"],
                                Motivos = (string)dataReader["motivos"],
                                TratamientoActual = (string)dataReader["tratamiento_actual"],
                                Alergico = (string)dataReader["alergico"],
                                Receta = (string)dataReader["receta"],
                                Atendida = (int)dataReader["atendida"],
                                Comentarios = (string)dataReader["comentarios"],
                                FechaCita = (string)dataReader["fecha_cita"]
                            });
                        }
                        respuesta.Datos = listaCitas;
                        break;
                    case 2:
                        SqlDataReader dataReader2 = cmd.ExecuteReader();
                        while (dataReader2.Read())
                        {
                            listaCitas.Add(new CitasRequest()
                            {
                                IdCita = (int)dataReader2["idCita"],
                                IdPaciente = (string)dataReader2["idPaciente"],
                                Doctor = (string)dataReader2["usuario_atiende"],
                                IdArea = (int)dataReader2["idArea"],
                                Signos = (string)dataReader2["signos"],
                                Motivos = (string)dataReader2["motivos"],
                                TratamientoActual = (string)dataReader2["tratamiento_actual"],
                                Alergico = (string)dataReader2["alergico"],
                                Receta = (string)dataReader2["receta"],
                                Atendida = (int)dataReader2["atendida"],
                                Comentarios = (string)dataReader2["comentarios"],
                                FechaCita = (string)dataReader2["fecha_cita"]
                            });
                        }
                        respuesta.Datos = listaCitas;
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
