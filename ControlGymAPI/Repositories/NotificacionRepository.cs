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
    public class NotificacionRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdNotificacion = 0;

        public List<NotificacionModel> RetrieveNotificacion(int id)
        {
            IdNotificacion = id;
            return RetrieveNotificacion();
        }

        public List<NotificacionModel> RetrieveNotificacion()
        {
            var listResult = new List<NotificacionModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Notificacion_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdNotificacion != 0)
                {
                    var parameter = new SqlParameter("@IdNotificacion", SqlDbType.Int) { Value = IdNotificacion };
                    command.Parameters.Add(parameter);
                    IdNotificacion = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new NotificacionModel();
                    if (SqlReader["IdNotificacion"] != DBNull.Value)
                    {
                        item.IdNotificacion = Convert.ToInt64(SqlReader["IdNotificacion"]);
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
                    if (SqlReader["IdTipoNotificacion"] != DBNull.Value)
                    {
                        item.IdTipoNotificacion = Convert.ToInt64(SqlReader["IdTipoNotificacion"]);
                    }
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        item.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
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

        public NotificacionModel InsertNotificacion(NotificacionModel Notificacion)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Notificacion_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdTipoNotificacion", SqlDbType.BigInt) { Value = Notificacion.IdTipoNotificacion };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@IdMiembro", SqlDbType.BigInt) { Value = Notificacion.IdMiembro };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdNotificacion"] != DBNull.Value)
                    {
                        Notificacion.IdNotificacion = Convert.ToInt64(SqlReader["IdNotificacion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Notificacion.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Notificacion.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Notificacion.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Notificacion.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Notificacion.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdTipoNotificacion"] != DBNull.Value)
                    {
                        Notificacion.IdTipoNotificacion = Convert.ToInt64(SqlReader["IdTipoNotificacion"]);
                    }
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        Notificacion.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
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
            return Notificacion;
        }

    }
}