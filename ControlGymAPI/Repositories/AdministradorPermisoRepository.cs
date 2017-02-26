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
    public class AdministradorPermisoRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdAdministradorPermiso = 0;

        public List<AdministradorPermisoModel> RetrieveAdministradorPermiso(int id)
        {
            IdAdministradorPermiso = id;
            return RetrieveAdministradorPermiso();
        }

        public List<AdministradorPermisoModel> RetrieveAdministradorPermiso()
        {
            var listResult = new List<AdministradorPermisoModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_AdministradorPermiso_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdAdministradorPermiso != 0)
                {
                    var parameter = new SqlParameter("@IdAdministradorPermiso", SqlDbType.Int) { Value = IdAdministradorPermiso };
                    command.Parameters.Add(parameter);
                    IdAdministradorPermiso = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new AdministradorPermisoModel();
                    if (SqlReader["IdAdministradorPermiso"] != DBNull.Value)
                    {
                        item.IdAdministradorPermiso = Convert.ToInt64(SqlReader["IdAdministradorPermiso"]);
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
                    if (SqlReader["IdAdministrador"] != DBNull.Value)
                    {
                        item.IdAdministrador = Convert.ToInt64(SqlReader["IdAdministrador"]);
                    }
                    if (SqlReader["IdPermiso"] != DBNull.Value)
                    {
                        item.IdPermiso = Convert.ToInt64(SqlReader["IdPermiso"]);
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

        public AdministradorPermisoModel InsertAdministradorPermiso(AdministradorPermisoModel AdministradorPermiso)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_AdministradorPermiso_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdAdministrador", SqlDbType.BigInt) { Value = AdministradorPermiso.IdAdministrador };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@IdPermiso", SqlDbType.BigInt) { Value = AdministradorPermiso.IdPermiso };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdAdministradorPermiso"] != DBNull.Value)
                    {
                        AdministradorPermiso.IdAdministradorPermiso = Convert.ToInt64(SqlReader["IdAdministradorPermiso"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        AdministradorPermiso.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        AdministradorPermiso.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        AdministradorPermiso.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        AdministradorPermiso.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        AdministradorPermiso.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdAdministrador"] != DBNull.Value)
                    {
                        AdministradorPermiso.IdAdministrador = Convert.ToInt64(SqlReader["IdAdministrador"]);
                    }
                    if (SqlReader["IdPermiso"] != DBNull.Value)
                    {
                        AdministradorPermiso.IdPermiso = Convert.ToInt64(SqlReader["IdPermiso"]);
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
            return AdministradorPermiso;
        }

    }
}