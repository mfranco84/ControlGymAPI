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
    public class PlanNutricionalRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdPlanNutricional = 0;

        public List<PlanNutricionalModel> RetrievePlanNutricional(int id)
        {
            IdPlanNutricional = id;
            return RetrievePlanNutricional();
        }

        public List<PlanNutricionalModel> RetrievePlanNutricional()
        {
            var listResult = new List<PlanNutricionalModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricional_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdPlanNutricional != 0)
                {
                    var parameter = new SqlParameter("@IdPlanNutricional", SqlDbType.Int) { Value = IdPlanNutricional };
                    command.Parameters.Add(parameter);
                    IdPlanNutricional = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new PlanNutricionalModel();
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        item.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
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
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        item.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        item.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["FechaInicio"] != DBNull.Value)
                    {
                        item.FechaInicio = Convert.ToDateTime(SqlReader["FechaInicio"]);
                    }
                    if (SqlReader["FechaFin"] != DBNull.Value)
                    {
                        item.FechaFin = Convert.ToDateTime(SqlReader["FechaFin"]);
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

        public PlanNutricionalModel InsertPlanNutricional(PlanNutricionalModel PlanNutricional)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_PlanNutricional_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdMiembro", SqlDbType.BigInt) { Value = PlanNutricional.IdMiembro };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = PlanNutricional.Nombre };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@FechaInicio", SqlDbType.DateTime) { Value = PlanNutricional.FechaInicio };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@FechaFin", SqlDbType.DateTime) { Value = PlanNutricional.FechaFin };
                command.Parameters.Add(parameter4);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdPlanNutricional"] != DBNull.Value)
                    {
                        PlanNutricional.IdPlanNutricional = Convert.ToInt64(SqlReader["IdPlanNutricional"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        PlanNutricional.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        PlanNutricional.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        PlanNutricional.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        PlanNutricional.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        PlanNutricional.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        PlanNutricional.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        PlanNutricional.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["FechaInicio"] != DBNull.Value)
                    {
                        PlanNutricional.FechaInicio = Convert.ToDateTime(SqlReader["FechaInicio"]);
                    }
                    if (SqlReader["FechaFin"] != DBNull.Value)
                    {
                        PlanNutricional.FechaFin = Convert.ToDateTime(SqlReader["FechaFin"]);
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
            return PlanNutricional;
        }

    }
}