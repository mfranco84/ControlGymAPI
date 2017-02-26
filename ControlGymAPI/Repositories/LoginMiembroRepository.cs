using ConnectionManage;
using ControlGymAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ControlGymAPI.Repositories
{
    public class LoginMiembroRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];

        /**
         * LoginMiembro: Realiza Login de Usuarios         
        **/
        public MiembroModel LoginMiembro(MiembroModel miembro)
        {
            var myConnection = new ConnectionManager(connectionString);
            var conexion = myConnection.CreateConnection();
            var command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Validar_Miembro";
                command.CommandType = CommandType.StoredProcedure;

                var parameter1 = new SqlParameter("@Correo", SqlDbType.VarChar) { Value = miembro.Correo };
                command.Parameters.Add(parameter1);

                var parameter2 = new SqlParameter("@Clave", SqlDbType.VarChar) { Value = miembro.Clave };
                command.Parameters.Add(parameter2);

                conexion.Open();

                SqlDataReader SqlReader = command.ExecuteReader();
                while (SqlReader.Read())
                {
                    miembro.IdMiembro = Convert.ToInt16(SqlReader["IdMiembro"]);
                    miembro.UsuInclusion = SqlReader["UsuInclusion"].ToString();
                    miembro.FechaInclusion = SqlReader.GetFieldValue<DateTime>(SqlReader.GetOrdinal("FechaInclusion"));
                    miembro.UsuModificacion = SqlReader["UsuModificacion"].ToString();
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        miembro.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    miembro.Estado = Convert.ToInt16(SqlReader["Estado"]);
                    miembro.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    miembro.Correo = SqlReader["Correo"].ToString();
                    miembro.Nombre = SqlReader["Nombre"].ToString();
                    miembro.Telefono = SqlReader["Telefono"].ToString();
                    miembro.CedulaIdentidad = SqlReader["CedulaIdentidad"].ToString();
                    miembro.Direccion = SqlReader["Direccion"].ToString();
                }
                miembro.Clave = string.Empty;
                return miembro;
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            finally
            {
                conexion.Close();
            }
            return miembro;
        }
    }
}