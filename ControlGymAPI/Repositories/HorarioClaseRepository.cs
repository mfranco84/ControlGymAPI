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
    public class HorarioClaseRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdHorarioClase = 0;

        public List<HorarioClaseModel> RetrieveHorarioClase(int id)
        {
            IdHorarioClase = id;
            return RetrieveHorarioClase();
        }

        public List<HorarioClaseModel> RetrieveHorarioClase()
        {
            var listResult = new List<HorarioClaseModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_HorarioClase_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdHorarioClase != 0)
                {
                    var parameter = new SqlParameter("@IdHorarioClase", SqlDbType.Int) { Value = IdHorarioClase };
                    command.Parameters.Add(parameter);
                    IdHorarioClase = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new HorarioClaseModel();
                    if (SqlReader["IdHorarioClase"] != DBNull.Value)
                    {
                        item.IdHorarioClase = Convert.ToInt64(SqlReader["IdHorarioClase"]);
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
                    if (SqlReader["IdClase"] != DBNull.Value)
                    {
                        item.IdClase = Convert.ToInt64(SqlReader["IdClase"]);
                    }
                    if (SqlReader["Dia"] != DBNull.Value)
                    {
                        item.Dia = Convert.ToString(SqlReader["Dia"]);
                    }
                    if (SqlReader["HoraInicio"] != DBNull.Value)
                    {
                        item.HoraInicio = TimeSpan.Parse(Convert.ToString(SqlReader["HoraInicio"]));
                    }
                    if (SqlReader["HoraFin"] != DBNull.Value)
                    {
                        item.HoraFin = TimeSpan.Parse(Convert.ToString(SqlReader["HoraFin"]));
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

        public List<HorarioClaseModel> RetrieveHorarioByClaseId(int claseId)
        {
            var listResult = new List<HorarioClaseModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_HorarioClaseClase_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("@IdClase", SqlDbType.Int) { Value = claseId };
                command.Parameters.Add(parameter);

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new HorarioClaseModel();
                    if (SqlReader["IdHorarioClase"] != DBNull.Value)
                    {
                        item.IdHorarioClase = Convert.ToInt64(SqlReader["IdHorarioClase"]);
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
                    if (SqlReader["IdClase"] != DBNull.Value)
                    {
                        item.IdClase = Convert.ToInt64(SqlReader["IdClase"]);
                    }
                    if (SqlReader["Dia"] != DBNull.Value)
                    {
                        item.Dia = Convert.ToString(SqlReader["Dia"]);
                    }
                    if (SqlReader["HoraInicio"] != DBNull.Value)
                    {
                        item.HoraInicio = TimeSpan.Parse(Convert.ToString(SqlReader["HoraInicio"]));
                    }
                    if (SqlReader["HoraFin"] != DBNull.Value)
                    {
                        item.HoraFin = TimeSpan.Parse(Convert.ToString(SqlReader["HoraFin"]));
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

        public HorarioClaseModel InsertHorarioClase(HorarioClaseModel HorarioClase)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_HorarioClase_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdClase", SqlDbType.BigInt) { Value = HorarioClase.IdClase };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Dia", SqlDbType.VarChar) { Value = HorarioClase.Dia };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@HoraInicio", SqlDbType.DateTime) { Value = HorarioClase.HoraInicio };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@HoraFin", SqlDbType.DateTime) { Value = HorarioClase.HoraFin };
                command.Parameters.Add(parameter4);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdHorarioClase"] != DBNull.Value)
                    {
                        HorarioClase.IdHorarioClase = Convert.ToInt64(SqlReader["IdHorarioClase"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        HorarioClase.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        HorarioClase.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        HorarioClase.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        HorarioClase.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        HorarioClase.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdClase"] != DBNull.Value)
                    {
                        HorarioClase.IdClase = Convert.ToInt64(SqlReader["IdClase"]);
                    }
                    if (SqlReader["Dia"] != DBNull.Value)
                    {
                        HorarioClase.Dia = Convert.ToString(SqlReader["Dia"]);
                    }
                    if (SqlReader["HoraInicio"] != DBNull.Value)
                    {
                        HorarioClase.HoraInicio = TimeSpan.Parse(Convert.ToString(SqlReader["HoraInicio"]));
                    }
                    if (SqlReader["HoraFin"] != DBNull.Value)
                    {
                        HorarioClase.HoraFin = TimeSpan.Parse(Convert.ToString(SqlReader["HoraFin"]));
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
            return HorarioClase;
        }

    }
}