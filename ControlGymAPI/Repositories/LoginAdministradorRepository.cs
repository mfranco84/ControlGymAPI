using ConnectionManage;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace ControlGymAPI.Repositories
{
    public class LoginAdministradorRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];

        /**
         * LoginAdministrador: Realiza Login de Usuarios         
        **/
        public AdministradorModel LoginAdministrador(AdministradorModel Administrador)
        {
            var myConnection = new ConnectionManager(connectionString);
            var conexion = myConnection.CreateConnection();
            var command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Validar_Administrador";
                command.CommandType = CommandType.StoredProcedure;

                var parameter1 = new SqlParameter("@Correo", SqlDbType.VarChar) { Value = Administrador.Correo };
                command.Parameters.Add(parameter1);

                var parameter2 = new SqlParameter("@Clave", SqlDbType.VarChar) { Value = Administrador.Clave };
                command.Parameters.Add(parameter2);

                conexion.Open();

                SqlDataReader SqlReader = command.ExecuteReader();
                while (SqlReader.Read())
                {
                    Administrador.IdAdministrador = Convert.ToInt16(SqlReader["IdAdministrador"]);
                    Administrador.UsuInclusion = SqlReader["UsuInclusion"].ToString();
                    Administrador.FechaInclusion = SqlReader.GetFieldValue<DateTime>(SqlReader.GetOrdinal("FechaInclusion"));
                    Administrador.UsuModificacion = SqlReader["UsuModificacion"].ToString();
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Administrador.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    Administrador.Estado = Convert.ToInt16(SqlReader["Estado"]);
                    Administrador.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    Administrador.Correo = SqlReader["Correo"].ToString();
                    Administrador.Nombre = SqlReader["Nombre"].ToString();
                    Administrador.Telefono = SqlReader["Telefono"].ToString();
                    Administrador.CedulaIdentidad = SqlReader["CedulaIdentidad"].ToString();
                    Administrador.Direccion = SqlReader["Direccion"].ToString();                    
                }
                Administrador.Clave = string.Empty;
                return Administrador;
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            finally
            {
                conexion.Close();
            }
            return Administrador;
        }
    }
}