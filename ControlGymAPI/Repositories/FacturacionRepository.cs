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
    public class FacturacionRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdFacturacion = 0;

        public List<FacturacionModel> RetrieveFacturacion(int id)
        {
            IdFacturacion = id;
            return RetrieveFacturacion();
        }

        public List<FacturacionModel> RetrieveFacturacion()
        {
            var listResult = new List<FacturacionModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Facturacion_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdFacturacion != 0)
                {
                    var parameter = new SqlParameter("@IdFacturacion", SqlDbType.Int) { Value = IdFacturacion };
                    command.Parameters.Add(parameter);
                    IdFacturacion = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new FacturacionModel();
                    if (SqlReader["IdFacturacion"] != DBNull.Value)
                    {
                        item.IdFacturacion = Convert.ToInt64(SqlReader["IdFacturacion"]);
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
                    if (SqlReader["IdGimnasio"] != DBNull.Value)
                    {
                        item.IdGimnasio = Convert.ToInt64(SqlReader["IdGimnasio"]);
                    }
                    if (SqlReader["FechaPago"] != DBNull.Value)
                    {
                        item.FechaPago = Convert.ToDateTime(SqlReader["FechaPago"]);
                    }
                    if (SqlReader["Monto"] != DBNull.Value)
                    {
                        item.Monto = Convert.ToDouble(SqlReader["Monto"]);
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

        public FacturacionModel InsertFacturacion(FacturacionModel Facturacion)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Facturacion_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdGimnasio", SqlDbType.BigInt) { Value = Facturacion.IdGimnasio };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@FechaPago", SqlDbType.DateTime) { Value = Facturacion.FechaPago };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Monto", SqlDbType.Decimal) { Value = Facturacion.Monto };
                command.Parameters.Add(parameter3);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdFacturacion"] != DBNull.Value)
                    {
                        Facturacion.IdFacturacion = Convert.ToInt64(SqlReader["IdFacturacion"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Facturacion.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Facturacion.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Facturacion.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Facturacion.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Facturacion.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdGimnasio"] != DBNull.Value)
                    {
                        Facturacion.IdGimnasio = Convert.ToInt64(SqlReader["IdGimnasio"]);
                    }
                    if (SqlReader["FechaPago"] != DBNull.Value)
                    {
                        Facturacion.FechaPago = Convert.ToDateTime(SqlReader["FechaPago"]);
                    }
                    if (SqlReader["Monto"] != DBNull.Value)
                    {
                        Facturacion.Monto = Convert.ToDouble(SqlReader["Monto"]);
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
            return Facturacion;
        }

    }
}