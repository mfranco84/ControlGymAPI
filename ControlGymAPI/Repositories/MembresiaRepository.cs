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
    public class MembresiaRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdMembresia = 0;

        public List<MembresiaModel> RetrieveMembresia(int id)
        {
            IdMembresia = id;
            return RetrieveMembresia();
        }

        public List<MembresiaModel> RetrieveMembresia()
        {
            var listResult = new List<MembresiaModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Membresia_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdMembresia != 0)
                {
                    var parameter = new SqlParameter("@IdMembresia", SqlDbType.Int) { Value = IdMembresia };
                    command.Parameters.Add(parameter);
                    IdMembresia = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new MembresiaModel();
                    if (SqlReader["IdMembresia"] != DBNull.Value)
                    {
                        item.IdMembresia = Convert.ToInt64(SqlReader["IdMembresia"]);
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
                    if (SqlReader["Monto"] != DBNull.Value)
                    {
                        item.Monto = Convert.ToDouble(SqlReader["Monto"]);
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

        public MembresiaModel InsertMembresia(MembresiaModel Membresia)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Membresia_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Membresia.Nombre };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Monto", SqlDbType.Decimal) { Value = Membresia.Monto };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Detalle", SqlDbType.VarChar) { Value = Membresia.Detalle };
                command.Parameters.Add(parameter3);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdMembresia"] != DBNull.Value)
                    {
                        Membresia.IdMembresia = Convert.ToInt64(SqlReader["IdMembresia"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Membresia.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Membresia.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Membresia.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Membresia.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Membresia.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        Membresia.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["Monto"] != DBNull.Value)
                    {
                        Membresia.Monto = Convert.ToDouble(SqlReader["Monto"]);
                    }
                    if (SqlReader["Detalle"] != DBNull.Value)
                    {
                        Membresia.Detalle = Convert.ToString(SqlReader["Detalle"]);
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
            return Membresia;
        }

    }
}