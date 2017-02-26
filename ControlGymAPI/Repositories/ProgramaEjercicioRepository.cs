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
    public class ProgramaEjercicioRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdProgramaEjercicio = 0;

        public List<ProgramaEjercicioModel> RetrieveProgramaEjercicio(int id)
        {
            IdProgramaEjercicio = id;
            return RetrieveProgramaEjercicio();
        }

        public List<ProgramaEjercicioModel> RetrieveProgramaEjercicio()
        {
            var listResult = new List<ProgramaEjercicioModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_ProgramaEjercicio_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdProgramaEjercicio != 0)
                {
                    var parameter = new SqlParameter("@IdProgramaEjercicio", SqlDbType.Int) { Value = IdProgramaEjercicio };
                    command.Parameters.Add(parameter);
                    IdProgramaEjercicio = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new ProgramaEjercicioModel();
                    if (SqlReader["IdProgramaEjercicio"] != DBNull.Value)
                    {
                        item.IdProgramaEjercicio = Convert.ToInt64(SqlReader["IdProgramaEjercicio"]);
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
                    if (SqlReader["NombrePrograma"] != DBNull.Value)
                    {
                        item.NombrePrograma = Convert.ToString(SqlReader["NombrePrograma"]);
                    }
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        item.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
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

        public ProgramaEjercicioModel InsertProgramaEjercicio(ProgramaEjercicioModel ProgramaEjercicio)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_ProgramaEjercicio_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@NombrePrograma", SqlDbType.VarChar) { Value = ProgramaEjercicio.NombrePrograma };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@IdMiembro", SqlDbType.BigInt) { Value = ProgramaEjercicio.IdMiembro };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@FechaInicio", SqlDbType.DateTime) { Value = ProgramaEjercicio.FechaInicio };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@FechaFin", SqlDbType.DateTime) { Value = ProgramaEjercicio.FechaFin };
                command.Parameters.Add(parameter4);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdProgramaEjercicio"] != DBNull.Value)
                    {
                        ProgramaEjercicio.IdProgramaEjercicio = Convert.ToInt64(SqlReader["IdProgramaEjercicio"]);
                    }
                    if (SqlReader["UsuInclusion"] != DBNull.Value)
                    {
                        ProgramaEjercicio.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    }
                    if (SqlReader["FechaInclusion"] != DBNull.Value)
                    {
                        ProgramaEjercicio.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    }
                    if (SqlReader["UsuModificacion"] != DBNull.Value)
                    {
                        ProgramaEjercicio.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    }
                    if (SqlReader["FechaModificacion"] != DBNull.Value)
                    {
                        ProgramaEjercicio.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    }
                    if (SqlReader["Estado"] != DBNull.Value)
                    {
                        ProgramaEjercicio.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    }
                    if (SqlReader["NombrePrograma"] != DBNull.Value)
                    {
                        ProgramaEjercicio.NombrePrograma = Convert.ToString(SqlReader["NombrePrograma"]);
                    }
                    if (SqlReader["IdMiembro"] != DBNull.Value)
                    {
                        ProgramaEjercicio.IdMiembro = Convert.ToInt64(SqlReader["IdMiembro"]);
                    }
                    if (SqlReader["FechaInicio"] != DBNull.Value)
                    {
                        ProgramaEjercicio.FechaInicio = Convert.ToDateTime(SqlReader["FechaInicio"]);
                    }
                    if (SqlReader["FechaFin"] != DBNull.Value)
                    {
                        ProgramaEjercicio.FechaFin = Convert.ToDateTime(SqlReader["FechaFin"]);
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
            return ProgramaEjercicio;
        }

    }
}