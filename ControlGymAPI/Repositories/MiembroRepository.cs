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
        /**
         * RetrieveMiembros: Regresa la lista de miembros
         * TODO: Modificar para  regresar solamente miembros pertenecientes a un gimnasio.
        **/
        public List<MiembroModel> RetrieveMiembros()
        {
            var listResult = new List<MiembroModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Miembro_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                SqlDataReader productReader = command.ExecuteReader();

                while (productReader.Read())
                {
                    var product = new MiembroModel
                    {
                        IdMiembro = Convert.ToInt16(productReader["IdMiembro"]),
                        //UsuInclusion = productReader["UsuInclusion"].ToString(),
                        //FechaInclusion = DateTime.Parse(productReader["FechaInclusion"].ToString()),
                        //UsuModificacion = productReader["UsuModificacion"].ToString(),
                        //FechaModificacion = DateTime.Parse(productReader["FechaModificacion"].ToString()),
                        Estado = Convert.ToInt16(productReader["Estado"]),
                        IdGimnasio = Convert.ToInt16(productReader["IdGimnasio"]),
                        Correo = productReader["Correo"].ToString(),
                        Nombre = productReader["Nombre"].ToString(),
                        Telefono = productReader["Telefono"].ToString(),
                        CedulaIdentidad = productReader["CedulaIdentidad"].ToString(),
                        Direccion = productReader["Direccion"].ToString(),
                    };
                    listResult.Add(product);
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

        public Boolean InsertMiembro(MiembroModel miembro)
        {
            var resultado = false;
            var myConnection = new ConnectionManager(connectionString);
            var conexion = myConnection.CreateConnection();
            var command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Miembro_Insertar";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@IdGimnasio", SqlDbType.Int) { Value = miembro.IdGimnasio };
                command.Parameters.Add(parameter);

                var parameter2 = new SqlParameter("@Correo", SqlDbType.Int) { Value = miembro.Correo };
                command.Parameters.Add(parameter2);

                var parameter3 = new SqlParameter("@Clave", SqlDbType.Int) { Value = miembro.Clave };
                command.Parameters.Add(parameter3);

                var parameter4 = new SqlParameter("@Nombre", SqlDbType.Int) { Value = miembro.Nombre };
                command.Parameters.Add(parameter4);

                var parameter5 = new SqlParameter("@Telefono", SqlDbType.Int) { Value = miembro.Telefono };
                command.Parameters.Add(parameter5);

                var parameter6 = new SqlParameter("@CedulaIdentidad", SqlDbType.Int) { Value = miembro.CedulaIdentidad };
                command.Parameters.Add(parameter6);

                var parameter7 = new SqlParameter("@Direccion", SqlDbType.Int) { Value = miembro.Direccion };
                command.Parameters.Add(parameter7);

                conexion.Open();
                command.ExecuteNonQuery();

                resultado = true;
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