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
    public class ClaseRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdClase = 0;

        public List<ClaseModel> RetrieveClase(int id)
        {
            IdClase = id;
            return RetrieveClase();
        }

        public List<ClaseModel> RetrieveClase()
        {
            var listResult = new List<ClaseModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Clase_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdClase != 0)
                {
                    var parameter = new SqlParameter("@IdClase", SqlDbType.Int) { Value = IdClase };
                    command.Parameters.Add(parameter);
                    IdClase = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new ClaseModel();
                    if (SqlReader["IdClase"] != DBNull.Value)
                    {
                        item.IdClase = Convert.ToInt64(SqlReader["IdClase"]);
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

        public ClaseModel InsertClase(ClaseModel Clase)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Clase_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Clase.Nombre };
                command.Parameters.Add(parameter1);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdClase"] != DBNull.Value)
                    {
                        Clase.IdClase = Convert.ToInt64(SqlReader["IdClase"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Clase.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Clase.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Clase.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Clase.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Clase.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        Clase.Nombre = Convert.ToString(SqlReader["Nombre"]);
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
            return Clase;
        }

    }
}