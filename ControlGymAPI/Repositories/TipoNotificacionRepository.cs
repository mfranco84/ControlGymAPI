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
    public class TipoNotificacionRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdTipoNotificacion = 0;

        public List<TipoNotificacionModel> RetrieveTipoNotificacion(int id)
        {
            IdTipoNotificacion = id;
            return RetrieveTipoNotificacion();
        }

        public List<TipoNotificacionModel> RetrieveTipoNotificacion()
        {
            var listResult = new List<TipoNotificacionModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_TipoNotificacion_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdTipoNotificacion != 0)
                {
                    var parameter = new SqlParameter("@IdTipoNotificacion", SqlDbType.Int) { Value = IdTipoNotificacion };
                    command.Parameters.Add(parameter);
                    IdTipoNotificacion = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new TipoNotificacionModel();
                    if (SqlReader["IdTipoNotificacion"] != DBNull.Value)
                    {
                        item.IdTipoNotificacion = Convert.ToInt64(SqlReader["IdTipoNotificacion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        item.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        item.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        item.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        item.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        item.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        item.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["Mensaje"] != DBNull.Value)
                    {
                        item.Mensaje = Convert.ToString(SqlReader["Mensaje"]);
                    }
                    if (SqlReader["Intervalo"] != DBNull.Value)
                    {
                        item.Intervalo = Convert.ToInt32(SqlReader["Intervalo"]);
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

        public TipoNotificacionModel InsertTipoNotificacion(TipoNotificacionModel TipoNotificacion)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_TipoNotificacion_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = TipoNotificacion.Nombre };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Mensaje", SqlDbType.VarChar) { Value = TipoNotificacion.Mensaje };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Intervalo", SqlDbType.Int) { Value = TipoNotificacion.Intervalo };
                command.Parameters.Add(parameter3);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdTipoNotificacion"] != DBNull.Value)
                    {
                        TipoNotificacion.IdTipoNotificacion = Convert.ToInt64(SqlReader["IdTipoNotificacion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        TipoNotificacion.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        TipoNotificacion.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        TipoNotificacion.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        TipoNotificacion.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        TipoNotificacion.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        TipoNotificacion.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["Mensaje"] != DBNull.Value)
                    {
                        TipoNotificacion.Mensaje = Convert.ToString(SqlReader["Mensaje"]);
                    }
                    if (SqlReader["Intervalo"] != DBNull.Value)
                    {
                        TipoNotificacion.Intervalo = Convert.ToInt32(SqlReader["Intervalo"]);
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
            return TipoNotificacion;
        }

    }
}