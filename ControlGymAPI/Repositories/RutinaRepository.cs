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
    public class RutinaRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdRutina = 0;

        public List<RutinaModel> RetrieveRutina(int id)
        {
            IdRutina = id;
            return RetrieveRutina();
        }

        public List<RutinaModel> RetrieveRutina()
        {
            var listResult = new List<RutinaModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Rutina_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdRutina != 0)
                {
                    var parameter = new SqlParameter("@IdRutina", SqlDbType.Int) { Value = IdRutina };
                    command.Parameters.Add(parameter);
                    IdRutina = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new RutinaModel();
                    if (SqlReader["IdRutina"] != DBNull.Value)
                    {
                        item.IdRutina = Convert.ToInt64(SqlReader["IdRutina"]);
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
                    if (SqlReader["IdProgramaEjercicio"] != DBNull.Value)
                    {
                        item.IdProgramaEjercicio = Convert.ToInt64(SqlReader["IdProgramaEjercicio"]);
                    }
                    if (SqlReader["NombreRutina"] != DBNull.Value)
                    {
                        item.NombreRutina = Convert.ToString(SqlReader["NombreRutina"]);
                    }
                    if (SqlReader["DetalleRutina"] != DBNull.Value)
                    {
                        item.DetalleRutina = Convert.ToString(SqlReader["DetalleRutina"]);
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

        public List<RutinaModel> RetrieveRutinaByProgramaId(int programaId)
        {
            var listResult = new List<RutinaModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_RutinaPrograma_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("@IdProgramaEjercicio", SqlDbType.Int) { Value = programaId };
                command.Parameters.Add(parameter);
                IdRutina = 0;

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new RutinaModel();
                    if (SqlReader["IdRutina"] != DBNull.Value)
                    {
                        item.IdRutina = Convert.ToInt64(SqlReader["IdRutina"]);
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
                    if (SqlReader["IdProgramaEjercicio"] != DBNull.Value)
                    {
                        item.IdProgramaEjercicio = Convert.ToInt64(SqlReader["IdProgramaEjercicio"]);
                    }
                    if (SqlReader["NombreRutina"] != DBNull.Value)
                    {
                        item.NombreRutina = Convert.ToString(SqlReader["NombreRutina"]);
                    }
                    if (SqlReader["DetalleRutina"] != DBNull.Value)
                    {
                        item.DetalleRutina = Convert.ToString(SqlReader["DetalleRutina"]);
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

        public RutinaModel InsertRutina(RutinaModel Rutina)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Rutina_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdProgramaEjercicio", SqlDbType.BigInt) { Value = Rutina.IdProgramaEjercicio };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@NombreRutina", SqlDbType.VarChar) { Value = Rutina.NombreRutina };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@DetalleRutina", SqlDbType.VarChar) { Value = Rutina.DetalleRutina };
                command.Parameters.Add(parameter3);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdRutina"] != DBNull.Value)
                    {
                        Rutina.IdRutina = Convert.ToInt64(SqlReader["IdRutina"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        Rutina.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        Rutina.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        Rutina.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        Rutina.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        Rutina.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["IdProgramaEjercicio"] != DBNull.Value)
                    {
                        Rutina.IdProgramaEjercicio = Convert.ToInt64(SqlReader["IdProgramaEjercicio"]);
                    }
                    if (SqlReader["NombreRutina"] != DBNull.Value)
                    {
                        Rutina.NombreRutina = Convert.ToString(SqlReader["NombreRutina"]);
                    }
                    if (SqlReader["DetalleRutina"] != DBNull.Value)
                    {
                        Rutina.DetalleRutina = Convert.ToString(SqlReader["DetalleRutina"]);
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
            return Rutina;
        }

    }
}