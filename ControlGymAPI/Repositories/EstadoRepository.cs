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
    public class EstadoRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdEstado = 0;

        public List<EstadoModel> RetrieveEstado(int id)
        {
            IdEstado = id;
            return RetrieveEstado();
        }

        public List<EstadoModel> RetrieveEstado()
        {
            var listResult = new List<EstadoModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Estado_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdEstado != 0)
                {
                    var parameter = new SqlParameter("@IdEstado", SqlDbType.Int) { Value = IdEstado };
                    command.Parameters.Add(parameter);
                    IdEstado = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new EstadoModel();
                    if (SqlReader["IdEstado"] != DBNull.Value)
                    {
                        item.IdEstado = Convert.ToInt32(SqlReader["IdEstado"]);
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
                    if (SqlReader["Descripcion"] != DBNull.Value)
                    {
                        item.Descripcion = Convert.ToString(SqlReader["Descripcion"]);
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

        public EstadoModel InsertEstado(EstadoModel Estado)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Estado_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdEstado", SqlDbType.Int) { Value = Estado.IdEstado };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = Estado.Descripcion };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdEstado"] != DBNull.Value)
                    {
                        Estado.IdEstado = Convert.ToInt32(SqlReader["IdEstado"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Estado.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Estado.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Estado.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Estado.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Estado.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Descripcion"] != DBNull.Value)
                    {
                        Estado.Descripcion = Convert.ToString(SqlReader["Descripcion"]);
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
            return Estado;
        }

    }
}