using GestorBackApi.Interface;
using GestorBackApi.Model;
using GestorBackApi.Util;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorBackApi.Implement
{
    public class CatalogoImplement : ConexionBD
    {
        private readonly SqlCommand cmd;
        private readonly SqlConnection conn;

        public CatalogoImplement() 
        {
            cmd = new SqlCommand();
            conn = new SqlConnection();
            cmd = GetCommand();
            conn = GetConnection();
        }

        public RespuestaGenerica GetCatalogo(int idCatalogo)
        {
            //instancia de la clase respuesta generica para retornar la respuesta del metodo
            RespuestaGenerica respuesta = new RespuestaGenerica();
            List<UsuarioModel> listaUsuario = new List<UsuarioModel>();
            List<CatalogoRol> listaRoles = new List<CatalogoRol>();
            List<CatalogoArea> listaAreas = new List<CatalogoArea>();
            List<CatalogoEstatus> listaEstatus = new List<CatalogoEstatus>();
            //se define el nombre del sp
            cmd.CommandText = "SP_GET_CATALOG";
            try
            {
                //se definen los parametros de entra del procedimiento almacenado(SP)
                cmd.Parameters.AddWithValue("@IDCAT", idCatalogo);
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
                if(idCatalogo > 0)
                {
                    switch (idCatalogo)
                    {
                        case 1:
                            SqlDataReader dataReader = cmd.ExecuteReader();
                            while (dataReader.Read())
                            {
                                listaUsuario.Add(new UsuarioModel()
                                {
                                    IdUsuario = (string)dataReader["usuario"],
                                    IdRol = (int)dataReader["idRol"],
                                    IdArea = (int)dataReader["idArea"],
                                    Nombre = (string)dataReader["nombre"],
                                    Paterno = (string)dataReader["appaterno"],
                                    Materno = (string)dataReader["apmaterno"],
                                    Edad = (int)dataReader["edad"],
                                    Sexo = Convert.ToChar((string)dataReader["sexo"]),
                                    Direccion = (string)dataReader["direccion"],
                                    Correo = (string)dataReader["correo"],
                                    Telefono = (string)dataReader["telefono"],
                                    Activo = (int)dataReader["activo"]
                                });
                            }
                            respuesta.Datos = listaUsuario;
                            break;
                        case 2:
                            SqlDataReader reader2 = cmd.ExecuteReader();
                            while (reader2.Read())
                            {
                                listaRoles.Add(new CatalogoRol()
                                {
                                    IdRol = (int)reader2["idRol"],
                                    Descripcion = (string)reader2["descRol"],
                                    fechaAlta = (string)reader2["fechaAlta"],
                                    Activo = (int)reader2["activo"],
                                });
                            }
                            respuesta.Datos = listaRoles;
                            break;
                        case 3:
                            SqlDataReader reader3 = cmd.ExecuteReader();
                            while (reader3.Read())
                            {
                                listaAreas.Add(new CatalogoArea()
                                {
                                    IdArea = (int)reader3["idArea"],
                                    Descripcion = (string)reader3["descArea"],
                                    fechaAlta = (string)reader3["fechaAlta"],
                                    Activo = (int)reader3["activo"],
                                });
                            }
                            respuesta.Datos = listaAreas;
                            break;
                        case 4:
                            SqlDataReader reader4 = cmd.ExecuteReader();
                            while (reader4.Read())
                            {
                                listaEstatus.Add(new CatalogoEstatus()
                                {
                                    IdEstatus = (int)reader4["idStatus"],
                                    Descripcion = (string)reader4["descStatus"],
                                    fechaAlta = (string)reader4["fechaAlta"],
                                    Activo = (int)reader4["activo"],
                                });
                            }
                            respuesta.Datos = listaEstatus;
                            break;
                    }
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
