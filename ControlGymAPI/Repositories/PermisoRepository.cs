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
    public class PermisoRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdPermiso = 0;

        public List<PermisoModel> RetrievePermiso(int id)
        {
            IdPermiso = id;
            return RetrievePermiso();
        }

        public List<PermisoModel> RetrievePermiso()
        {
            var listResult = new List<PermisoModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Permiso_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdPermiso != 0)
                {
                    var parameter = new SqlParameter("@IdPermiso", SqlDbType.Int) { Value = IdPermiso };
                    command.Parameters.Add(parameter);
                    IdPermiso = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new PermisoModel();
                    if (SqlReader["IdPermiso"] != DBNull.Value)
                    {
                        item.IdPermiso = Convert.ToInt64(SqlReader["IdPermiso"]);
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
                    if (SqlReader["Detalle"] != DBNull.Value)
                    {
                        item.Detalle = Convert.ToString(SqlReader["Detalle"]);
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

        public PermisoModel InsertPermiso(PermisoModel Permiso)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Permiso_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Permiso.Nombre };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Detalle", SqlDbType.VarChar) { Value = Permiso.Detalle };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdPermiso"] != DBNull.Value)
                    {
                        Permiso.IdPermiso = Convert.ToInt64(SqlReader["IdPermiso"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Permiso.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Permiso.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Permiso.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Permiso.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Permiso.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        Permiso.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["Detalle"] != DBNull.Value)
                    {
                        Permiso.Detalle = Convert.ToString(SqlReader["Detalle"]);
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
            return Permiso;
        }

    }
}