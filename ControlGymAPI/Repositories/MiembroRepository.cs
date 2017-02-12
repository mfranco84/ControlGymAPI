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
    }
}