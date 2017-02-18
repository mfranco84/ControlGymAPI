using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManage;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using ControlGymAPI.Models;

namespace ControlGymAPI.Repositories
{
    public class MiembroRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int miembroId = 0 ;

        public List<MiembroModel> RetrieveMiembro(int id)
        {
            miembroId = id;
            return RetrieveMiembros();
        }
        /**
         * RetrieveMiembros: Regresa la lista de miembros
         * TODO: Modificar para  regresar solamente miembros pertenecientes a un gimnasio.
        **/
        public List<MiembroModel> RetrieveMiembros( )
        {
            var listResult = new List<MiembroModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Miembro_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (miembroId != 0)
                {
                    var parameter = new SqlParameter("@IdMiembro", SqlDbType.Int) { Value = miembroId };
                    command.Parameters.Add(parameter);
                    miembroId = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var miembro = new MiembroModel();

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
                    listResult.Add(miembro);
                }
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            finally
            {
                conexion.Close();
            }
            return listResult;
        }

        public MiembroModel InsertMiembro(MiembroModel miembro)
        {
            MiembroModel resultado = new MiembroModel();
            var myConnection = new ConnectionManager(connectionString);
            var conexion = myConnection.CreateConnection();
            var command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Miembro_Insertar";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@IdGimnasio", SqlDbType.Int) { Value = miembro.IdGimnasio };
                command.Parameters.Add(parameter);

                var parameter2 = new SqlParameter("@Correo", SqlDbType.VarChar) { Value = miembro.Correo };
                command.Parameters.Add(parameter2);

                var parameter3 = new SqlParameter("@Clave", SqlDbType.VarChar) { Value = "clave" }; //Definir clave dinamicamente
                command.Parameters.Add(parameter3);

                var parameter4 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = miembro.Nombre };
                command.Parameters.Add(parameter4);

                var parameter5 = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = miembro.Telefono };
                command.Parameters.Add(parameter5);

                var parameter6 = new SqlParameter("@CedulaIdentidad", SqlDbType.VarChar) { Value = miembro.CedulaIdentidad };
                command.Parameters.Add(parameter6);

                var parameter7 = new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = miembro.Direccion };
                command.Parameters.Add(parameter7);

                conexion.Open();
                //command.ExecuteNonQuery();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    resultado = new MiembroModel();

                    resultado.IdMiembro = Convert.ToInt16(SqlReader["IdMiembro"]);
                    resultado.UsuInclusion = SqlReader["UsuInclusion"].ToString();
                    resultado.FechaInclusion = SqlReader.GetFieldValue<DateTime>(SqlReader.GetOrdinal("FechaInclusion"));
                    resultado.UsuModificacion = SqlReader["UsuModificacion"].ToString();
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        resultado.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    resultado.Estado = Convert.ToInt16(SqlReader["Estado"]);
                    resultado.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    resultado.Correo = SqlReader["Correo"].ToString();
                    resultado.Nombre = SqlReader["Nombre"].ToString();
                    resultado.Telefono = SqlReader["Telefono"].ToString();
                    resultado.CedulaIdentidad = SqlReader["CedulaIdentidad"].ToString();
                    resultado.Direccion = SqlReader["Direccion"].ToString();
                }
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
    }
}