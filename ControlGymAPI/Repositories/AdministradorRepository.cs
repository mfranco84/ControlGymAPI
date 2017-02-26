//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:19:31 a.m.
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
    public class AdministradorRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        int IdAdministrador = 0;

        public List<AdministradorModel> RetrieveAdministrador(int id)
        {
            IdAdministrador = id;
            return RetrieveAdministrador();
        }

        public List<AdministradorModel> RetrieveAdministrador()
        {
            var listResult = new List<AdministradorModel>();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Administrador_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;
                if (IdAdministrador != 0)
                {
                    var parameter = new SqlParameter("@IdAdministrador", SqlDbType.Int) { Value = IdAdministrador };
                    command.Parameters.Add(parameter);
                    IdAdministrador = 0;
                }

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    var item = new AdministradorModel();
                    if (SqlReader["IdAdministrador"] != DBNull.Value)
                    {
                        item.IdAdministrador = Convert.ToInt32(SqlReader["IdAdministrador"]);
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
                        item.IdGimnasio = Convert.ToInt32(SqlReader["IdGimnasio"]);
                    }
                    if (SqlReader["Correo"] != DBNull.Value)
                    {
                        item.Correo = Convert.ToString(SqlReader["Correo"]);
                    }
                    if (SqlReader["Clave"] != DBNull.Value)
                    {
                        item.Clave = Convert.ToString(SqlReader["Clave"]);
                    }
                    if (SqlReader["Nombre"] != DBNull.Value)
                    {
                        item.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    }
                    if (SqlReader["Telefono"] != DBNull.Value)
                    {
                        item.Telefono = Convert.ToString(SqlReader["Telefono"]);
                    }
                    if (SqlReader["CedulaJuridica"] != DBNull.Value)
                    {
                        item.CedulaJuridica = Convert.ToString(SqlReader["CedulaJuridica"]);
                    }
                    if (SqlReader["Direccion"] != DBNull.Value)
                    {
                        item.Direccion = Convert.ToString(SqlReader["Direccion"]);
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

        public AdministradorModel InsertAdministrador(AdministradorModel Administrador)
        {
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Administrador_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdGimnasio", SqlDbType.BigInt) { Value = Administrador.IdGimnasio };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@Correo", SqlDbType.VarChar) { Value = Administrador.Correo };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@Clave", SqlDbType.VarChar) { Value = Administrador.Clave };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Administrador.Nombre };
                command.Parameters.Add(parameter4);
                var parameter5 = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Administrador.Telefono };
                command.Parameters.Add(parameter5);
                var parameter6 = new SqlParameter("@CedulaJuridica", SqlDbType.VarChar) { Value = Administrador.CedulaJuridica };
                command.Parameters.Add(parameter6);
                var parameter7 = new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = Administrador.Direccion };
                command.Parameters.Add(parameter7);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    Administrador.IdAdministrador = Convert.ToInt32(SqlReader["IdAdministrador"]);
                    Administrador.UsuInclusion = Convert.ToString(SqlReader["UsuInclusion"]);
                    Administrador.FechaInclusion = Convert.ToDateTime(SqlReader["FechaInclusion"]);
                    Administrador.UsuModificacion = Convert.ToString(SqlReader["UsuModificacion"]);
                    Administrador.FechaModificacion = Convert.ToDateTime(SqlReader["FechaModificacion"]);
                    Administrador.Estado = Convert.ToInt32(SqlReader["Estado"]);
                    Administrador.IdGimnasio = Convert.ToInt32(SqlReader["IdGimnasio"]);
                    Administrador.Correo = Convert.ToString(SqlReader["Correo"]);
                    Administrador.Clave = Convert.ToString(SqlReader["Clave"]);
                    Administrador.Nombre = Convert.ToString(SqlReader["Nombre"]);
                    Administrador.Telefono = Convert.ToString(SqlReader["Telefono"]);
                    Administrador.CedulaJuridica = Convert.ToString(SqlReader["CedulaJuridica"]);
                    Administrador.Direccion = Convert.ToString(SqlReader["Direccion"]);
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
            return Administrador;
        }

    }
}