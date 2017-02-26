//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:53:22 a.m.
//Comentario: Generacion API

using System;
using System.Collections.Generic;
using ConnectionManage;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using ControlGymAPI.Models;

namespace ControlGymAPI.Repositories
{
    public class ExcepcionRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdExcepcion = 0;

        public List<ExcepcionModel> RetrieveExcepcion(int id)
        {
            IdExcepcion = id;
            return RetrieveExcepcion();
        }

        public List<ExcepcionModel> RetrieveExcepcion()
        {
            var listResult = new List<ExcepcionModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Excepcion_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdExcepcion != 0)
                {
                    var parameter = new SqlParameter("@IdExcepcion", SqlDbType.Int) { Value = IdExcepcion };
                    command.Parameters.Add(parameter);
                    IdExcepcion = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new ExcepcionModel();
                    if (SqlReader["IdExcepcion"] != DBNull.Value)
                    {
                        item.IdExcepcion = Convert.ToInt32(SqlReader["IdExcepcion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        item.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        item.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["Numero_Error"] != DBNull.Value)
                    {
                        item.Numero_Error = Convert.ToInt32(SqlReader["Numero_Error"]);
                    }
                    if (SqlReader["Linea_Error"] != DBNull.Value)
                    {
                        item.Linea_Error = Convert.ToInt32(SqlReader["Linea_Error"]);
                    }
                    if (SqlReader["Procedimiento_Error"] != DBNull.Value)
                    {
                        item.Procedimiento_Error = Convert.ToString(SqlReader["Procedimiento_Error"]);
                    }
                    if (SqlReader["Mensaje_Error"] != DBNull.Value)
                    {
                        item.Mensaje_Error = Convert.ToString(SqlReader["Mensaje_Error"]);
                    }
                    if (SqlReader["Parametros_Error"] != DBNull.Value)
                    {
                        item.Parametros_Error = Convert.ToString(SqlReader["Parametros_Error"]);
                    }
                    listResult.Add(item);
                }
            }
            catch (Exception exception)
            {
                //Definir Log de Errores
            }
            finally
            {
                conexion.Close();
            }
            return listResult;
        }

        public ExcepcionModel InsertExcepcion(ExcepcionModel Excepcion)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Excepcion_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@Numero_Error", SqlDbType.Int) { Value = Excepcion.Numero_Error };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Linea_Error", SqlDbType.Int) { Value = Excepcion.Linea_Error };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Procedimiento_Error", SqlDbType.VarChar) { Value = Excepcion.Procedimiento_Error };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@Mensaje_Error", SqlDbType.VarChar) { Value = Excepcion.Mensaje_Error };
                command.Parameters.Add(parameter4);
                var parameter5 = new SqlParameter("@Parametros_Error", SqlDbType.VarChar) { Value = Excepcion.Parametros_Error };
                command.Parameters.Add(parameter5);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdExcepcion"] != DBNull.Value)
                    {
                        Excepcion.IdExcepcion = Convert.ToInt32(SqlReader["IdExcepcion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Excepcion.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Excepcion.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["Numero_Error"] != DBNull.Value)
                    {
                        Excepcion.Numero_Error = Convert.ToInt32(SqlReader["Numero_Error"]);
                    }
                    if (SqlReader["Linea_Error"] != DBNull.Value)
                    {
                        Excepcion.Linea_Error = Convert.ToInt32(SqlReader["Linea_Error"]);
                    }
                    if (SqlReader["Procedimiento_Error"] != DBNull.Value)
                    {
                        Excepcion.Procedimiento_Error = Convert.ToString(SqlReader["Procedimiento_Error"]);
                    }
                    if (SqlReader["Mensaje_Error"] != DBNull.Value)
                    {
                        Excepcion.Mensaje_Error = Convert.ToString(SqlReader["Mensaje_Error"]);
                    }
                    if (SqlReader["Parametros_Error"] != DBNull.Value)
                    {
                        Excepcion.Parametros_Error = Convert.ToString(SqlReader["Parametros_Error"]);
                    }
                }
            }
            catch (Exception exception)
            {
                //Definir Log de Errores
            }
            finally
            {
                conexion.Close();
            }
            return Excepcion;
        }

    }
}