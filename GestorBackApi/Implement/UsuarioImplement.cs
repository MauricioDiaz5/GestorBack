using GestorBackApi.Model;
using GestorBackApi.Util;
using System.Data;
using System.Data.SqlClient;

namespace GestorBackApi.Implement
{
    public class UsuarioImplement : ConexionBD
    {

        private readonly SqlCommand cmd;
        private readonly SqlConnection conn;

        //metodo constructor
        public UsuarioImplement()
        {
            cmd = new SqlCommand();
            conn = new SqlConnection();
            cmd = GetCommand();
            conn = GetConnection();
        }

        //metodo para validar inicio de session en base de datos
        public RespuestaGenerica ValidaSessionBD(SessionRequest session)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            //se define el nombre del sp
            cmd.CommandText = "SP_GET_USER";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@USUARIO", session.Usuario);
                cmd.Parameters.AddWithValue("@CONTRASENA", session.Contrasena);
                //se definen parametros de salida del SP
                cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EXISTE", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@USER", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@APPATERNO", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@APMATERNO", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EDAD", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SEXO", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ROL", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ACTIVO", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AREA", SqlDbType.Int).Direction = ParameterDirection.Output;
                //se abre la conexion con la base de datos
                conn.Open();
                //se ejecuta el sp 
                int i = cmd.ExecuteNonQuery();
                //recuperacion de codigo y mensaje retornados por el sp
                respuesta.Codigo = Convert.ToInt32(cmd.Parameters["@CODIGO"].Value);
                respuesta.Mensaje = Convert.ToString(cmd.Parameters["@MENSAJE"].Value);
                //recupéracion de la informacion del usuario retornada por el sp
                UsuarioModel usuario = new UsuarioModel
                {
                    IdUsuario = Convert.ToString(cmd.Parameters["@USER"].Value),
                    Nombre = Convert.ToString(cmd.Parameters["@NOMBRE"].Value),
                    Paterno = Convert.ToString(cmd.Parameters["@APPATERNO"].Value),
                    Materno = Convert.ToString(cmd.Parameters["@APMATERNO"].Value),
                    Edad = Convert.ToInt32(cmd.Parameters["@EDAD"].Value),
                    Sexo = Convert.ToChar(cmd.Parameters["@SEXO"].Value),
                    Telefono = Convert.ToString(cmd.Parameters["@TELEFONO"].Value),
                    Correo = Convert.ToString(cmd.Parameters["@CORREO"].Value),
                    Direccion = Convert.ToString(cmd.Parameters["@DIRECCION"].Value),
                    IdRol = Convert.ToInt32(cmd.Parameters["@ROL"].Value),
                    Activo = Convert.ToInt32(cmd.Parameters["@ACTIVO"].Value),
                    IdArea = Convert.ToInt32(cmd.Parameters["@AREA"].Value)
                };
                //se asigna el objeto usuario al objeto datos de la respuesta generica
                respuesta.Datos = usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public RespuestaGenerica ValidaUsuarioBD(string usuario)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            //se define el nombre del sp
            cmd.CommandText = "SP_GET_EXIST_USER";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                //se definen parametros de salida del SP
                cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EXISTE", SqlDbType.Int).Direction = ParameterDirection.Output;
                //se abre la conexion con la base de datos
                conn.Open();
                //se ejecuta el sp 
                int i = cmd.ExecuteNonQuery();
                //recuperacion de codigo, mensaje y datos retornados por el sp
                respuesta.Codigo = Convert.ToInt32(cmd.Parameters["@CODIGO"].Value);
                respuesta.Mensaje = Convert.ToString(cmd.Parameters["@MENSAJE"].Value);
                respuesta.Datos = Convert.ToInt32(cmd.Parameters["@EXISTE"].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }

        public RespuestaGenerica AltaUsuarioBD(UsuarioModel usuario)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            //se define el nombre del sp
            cmd.CommandText = "SP_SET_USUARIO";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@USUARIO", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@IDROL", usuario.IdRol);
                cmd.Parameters.AddWithValue("@IDAREA", usuario.IdArea);
                cmd.Parameters.AddWithValue("@NOMBRE", usuario.Nombre);
                cmd.Parameters.AddWithValue("@APPATERNO", usuario.Paterno);
                cmd.Parameters.AddWithValue("@APMATERNO", usuario.Materno);
                cmd.Parameters.AddWithValue("@EDAD", usuario.Edad);
                cmd.Parameters.AddWithValue("@SEXO", usuario.Sexo);
                cmd.Parameters.AddWithValue("@DIRECCION", usuario.Direccion);
                cmd.Parameters.AddWithValue("@CORREO", usuario.Correo);
                cmd.Parameters.AddWithValue("@CONTRASENA", usuario.Contrasena);
                cmd.Parameters.AddWithValue("@FECHAALTA", usuario.FechaAlta);
                cmd.Parameters.AddWithValue("@ACTIVO", usuario.Activo);
                cmd.Parameters.AddWithValue("@TELEFONO", usuario.Telefono);

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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}
