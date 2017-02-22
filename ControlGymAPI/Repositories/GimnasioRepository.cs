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
    public class GimnasioRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int GimnasioId = 0;

        public List<GimnasioModel> RetrieveGimnasio(int id)
        {
            GimnasioId = id;
            return RetrieveGimnasios();
        }
        /**
         * RetrieveGimnasios: Regresa la lista de Gimnasios
         * TODO: Modificar para  regresar solamente Gimnasios pertenecientes a un gimnasio.
        **/
        public List<GimnasioModel> RetrieveGimnasios()
        {
            var listResult = new List<GimnasioModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Gimnasio_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (GimnasioId != 0)
                {
                    var parameter = new SqlParameter("@IdGimnasio", SqlDbType.Int) { Value = GimnasioId };
                    command.Parameters.Add(parameter);
                    GimnasioId = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var Gimnasio = new GimnasioModel();

                    Gimnasio.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    Gimnasio.UsuInclusion = SqlReader["UsuInclusion"].ToString();
                    Gimnasio.FechaInclusion = SqlReader.GetFieldValue<DateTime>(SqlReader.GetOrdinal("FechaInclusion"));
                    Gimnasio.UsuModificacion = SqlReader["UsuModificacion"].ToString();
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Gimnasio.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    Gimnasio.Estado = Convert.ToInt16(SqlReader["Estado"]);
                    Gimnasio.IdMembresia = Convert.ToInt16(SqlReader["IdMembresia"]);
                    Gimnasio.Nombre = SqlReader["Nombre"].ToString();
                    listResult.Add(Gimnasio);
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

        public GimnasioModel InsertGimnasio(GimnasioModel Gimnasio)
        {
            GimnasioModel resultado = new GimnasioModel();
            var myConnection = new ConnectionManager(connectionString);
            var conexion = myConnection.CreateConnection();
            var command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Gimnasio_Insertar";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@IdMembresia", SqlDbType.Int) { Value = Gimnasio.IdMembresia };
                command.Parameters.Add(parameter);

                var parameter2 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Gimnasio.Nombre };
                command.Parameters.Add(parameter2);


                conexion.Open();
                //command.ExecuteNonQuery();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    resultado = new GimnasioModel();

                    resultado.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    resultado.UsuInclusion = SqlReader["UsuInclusion"].ToString();
                    resultado.FechaInclusion = SqlReader.GetFieldValue<DateTime>(SqlReader.GetOrdinal("FechaInclusion"));
                    resultado.UsuModificacion = SqlReader["UsuModificacion"].ToString();
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        resultado.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    resultado.Estado = Convert.ToInt16(SqlReader["Estado"]);
                    resultado.IdGimnasio = Convert.ToInt16(SqlReader["IdGimnasio"]);
                    resultado.Nombre = SqlReader["Nombre"].ToString();

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