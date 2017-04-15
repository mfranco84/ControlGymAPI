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
    public class PlanNutricionalDetalleRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdPlanNutricionalDetalle = 0;

        public List<PlanNutricionalDetalleModel> RetrievePlanNutricionalDetalle(int id)
        {
            IdPlanNutricionalDetalle = id;
            return RetrievePlanNutricionalDetalle();
        }

        public List<PlanNutricionalDetalleModel> RetrievePlanNutricionalDetalle()
        {
            var listResult = new List<PlanNutricionalDetalleModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricionalDetalle_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdPlanNutricionalDetalle != 0)
                {
                    var parameter = new SqlParameter("@IdPlanNutricionalDetalle", SqlDbType.Int) { Value = IdPlanNutricionalDetalle };
                    command.Parameters.Add(parameter);
                    IdPlanNutricionalDetalle = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new PlanNutricionalDetalleModel();
                    if (SqlReader["IdPlanNutricionalDetalle"] != DBNull.Value)
                    {
                        item.IdPlanNutricionalDetalle = Convert.ToInt64(SqlReader["IdPlanNutricionalDetalle"]);
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
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        item.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
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


        public List<PlanNutricionalDetalleModel> RetrievePlanNutrionalByPlanId(int planId)
        {
            var listResult = new List<PlanNutricionalDetalleModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricionalDetallePlan_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("@IdPlanNutricional", SqlDbType.Int) { Value = planId };
                command.Parameters.Add(parameter);
                IdPlanNutricionalDetalle = 0;

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new PlanNutricionalDetalleModel();
                    if (SqlReader["IdPlanNutricionalDetalle"] != DBNull.Value)
                    {
                        item.IdPlanNutricionalDetalle = Convert.ToInt64(SqlReader["IdPlanNutricionalDetalle"]);
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
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        item.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
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

        public PlanNutricionalDetalleModel InsertPlanNutricionalDetalle(PlanNutricionalDetalleModel PlanNutricionalDetalle)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricionalDetalle_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdPlanNutricional", SqlDbType.BigInt) { Value = PlanNutricionalDetalle.IdPlanNutricional };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Detalle", SqlDbType.VarChar) { Value = PlanNutricionalDetalle.Detalle };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdPlanNutricionalDetalle"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.IdPlanNutricionalDetalle = Convert.ToInt64(SqlReader["IdPlanNutricionalDetalle"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
                    }
                    if (SqlReader["Detalle"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.Detalle = Convert.ToString(SqlReader["Detalle"]);
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
            return PlanNutricionalDetalle;
        }

        public PlanNutricionalDetalleModel UpdatePlanNutricionalDetalle(PlanNutricionalDetalleModel PlanNutricionalDetalle)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricionalDetalle_Actualizar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("@IdPlanNutricionalDetalle", SqlDbType.BigInt) { Value = PlanNutricionalDetalle.IdPlanNutricionalDetalle };
                command.Parameters.Add(parameter);
                var parameter1 = new SqlParameter("@IdPlanNutricional", SqlDbType.BigInt) { Value = PlanNutricionalDetalle.IdPlanNutricional };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Detalle", SqlDbType.VarChar) { Value = PlanNutricionalDetalle.Detalle };
                command.Parameters.Add(parameter2);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdPlanNutricionalDetalle"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.IdPlanNutricionalDetalle = Convert.ToInt64(SqlReader["IdPlanNutricionalDetalle"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
                    }
                    if (SqlReader["Detalle"] != DBNull.Value)
                    {
                        PlanNutricionalDetalle.Detalle = Convert.ToString(SqlReader["Detalle"]);
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
            return PlanNutricionalDetalle;
        }

        public void DeletePlanNutricionalDetalle(int IdPlanNutricionalDetalle)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricionalDetalle_Eliminar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("@IdPlanNutricionalDetalle", SqlDbType.BigInt) { Value = IdPlanNutricionalDetalle };
                command.Parameters.Add(parameter);
                conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                //Definir Log de Errores
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}