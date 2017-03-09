using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ControlGymAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using ConnectionManage;

namespace ControlGymAPI.Repositories
{
    public class AuthRepository
    {
        string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];

        // TODO:

        //1- Crear Tabla "auth_token", campos:
        //    IdUsuario int, 
        //    IdOrganizacion int, 
        //    tipoUsuario enum("miembro" o "administrador"), 
        //    fechaHoraLogin datetime, 
        //    fechaHoraExpiracion datetime,
        //    token string

        /**
         * Este metodo tiene que ser llamado en cada funcion publica
         * de cada controlador, para verificar que el usuario esta logueado en el sistema.
         **/
        public bool ValidateToken(HttpRequestMessage request)
        {

            IEnumerable<string> headerValues;
            var tokenHeader = string.Empty;
            // Validando la entrada del token como un header 'cgToken'
            if (request.Headers.TryGetValues("Authorization", out headerValues))
            {
                tokenHeader = headerValues.FirstOrDefault();

                //TODO: StoreProcedure para obtener el registro del token con base en tokenHeader
                //parsear datos a la clase AuthModel
                AuthModel auth = new AuthModel();

                auth = RetrieveAutorizacion(tokenHeader);

                if (tokenHeader == auth.Token)
                {
                    // Verificar que la fecha y hora actual sean menores que fechaHoraExpiracion
                    bool diferenciaTiempo = DateTime.Now < auth.FechaHoraExpiracion;
                    if (diferenciaTiempo)
                    {
                        // Actualizar tiempo de expiracion de token segun tipo de usuario
                        if (auth.TipoUsuario == "Administrador")
                        {
                            // Si es administrador, se le aumenta 1 hora desde el momento actual
                            auth.FechaHoraExpiracion = DateTime.Now.AddMinutes(60);
                        }
                        else
                        {
                            // Si es miembro, se le aumenta 1 mes desde el momento actual
                            auth.FechaHoraExpiracion = DateTime.Now.AddMonths(1);
                        }
                        //TODO: StoreProcedure para actualizar 'FechaHoraExpiracion' del registro del token
                        UpdateAutorizacion(auth.Token, auth.FechaHoraExpiracion);
                        // Alojar datos de usuario autorizado (miembro/administrador) en una variable global
                        // para su posterior uso en los diferentes stored procedures
                        GlobalAuth.IdGimnasio = auth.IdGimnasio;
                        GlobalAuth.IdUsuario = auth.IdUsuario;
                        GlobalAuth.TipoUsuario = auth.TipoUsuario;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public AuthModel RetrieveAutorizacion(string tokenHeader)
        {
            AuthModel auth = new AuthModel();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Autorizacion_Seleccionar";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Token", SqlDbType.VarChar) { Value = tokenHeader };
                command.Parameters.Add(parameter);
                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["IdUsuario"] != DBNull.Value)
                    {
                        auth.IdUsuario = Convert.ToInt32(SqlReader["IdUsuario"]);
                    }
                    if (SqlReader["IdGimnasio"] != DBNull.Value)
                    {
                        auth.IdGimnasio = Convert.ToInt32(SqlReader["IdGimnasio"]);
                    }
                    if (SqlReader["TipoUsuario"] != DBNull.Value)
                    {
                        auth.TipoUsuario = Convert.ToString(SqlReader["TipoUsuario"]);
                    }
                    if (SqlReader["FechaHoraLogin"] != DBNull.Value)
                    {
                        auth.FechaHoraLogin = Convert.ToDateTime(SqlReader["FechaHoraLogin"]);
                    }
                    if (SqlReader["FechaHoraExpiracion"] != DBNull.Value)
                    {
                        auth.FechaHoraExpiracion = Convert.ToDateTime(SqlReader["FechaHoraExpiracion"]);
                    }
                    if (SqlReader["Token"] != DBNull.Value)
                    {
                        auth.Token = Convert.ToString(SqlReader["Token"]);
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
            return auth;
        }

        public void UpdateAutorizacion(string tokenHeader, DateTime fechaHoraExpiracion)
        {
            AuthModel auth = new AuthModel();
            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Autorizacion_Actualizar";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Token", SqlDbType.VarChar) { Value = tokenHeader };
                command.Parameters.Add(parameter);
                var parameter1 = new SqlParameter("@FechaHoraExpiracion", SqlDbType.DateTime) { Value = fechaHoraExpiracion };
                command.Parameters.Add(parameter1);
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

        public string RegistrarToken(int usuarioId, int GimnasioId, string tipoUsuario)
        {
            string token=string.Empty;
            DateTime fechaHoraLogin = DateTime.Now;
            DateTime fechaHoraExpiracion = (tipoUsuario == "Administrador") ? fechaHoraLogin.AddHours(1) : fechaHoraLogin.AddMonths(1);

            // TODO: Implementar logica para crear un registro para cada login.
            // 2- El valor de la columna fecha_hora_expiracion es:
            //        - para administrador: fecha_hora_login + 60 minutos
            //        - para miembro: fecha_hora_login + 1 mes.
            // 3- El valor del token, ejemplo: http://stackoverflow.com/questions/14643735/how-to-generate-a-unique-token-which-expires-after-24-hours
            // 4- Este metodo debe devolver el token, el cual será agregado al objeto
            //    miembro o administrador que retornan las respectivas funciones de login. 

            var myConnection = new ConnectionManager(connectionString);
            SqlConnection conexion = myConnection.CreateConnection();
            SqlCommand command = myConnection.CreateCommand(conexion);
            try
            {
                command.CommandText = "usp_Autorizacion_Insertar";
                command.CommandType = CommandType.StoredProcedure;
                var parameter1 = new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = usuarioId };
                command.Parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@IdGimnasio", SqlDbType.BigInt) { Value = GimnasioId };
                command.Parameters.Add(parameter2);
                var parameter3 = new SqlParameter("@TipoUsuario", SqlDbType.VarChar) { Value = tipoUsuario };
                command.Parameters.Add(parameter3);
                var parameter4 = new SqlParameter("@FechaHoraLogin", SqlDbType.DateTime) { Value = fechaHoraLogin };
                command.Parameters.Add(parameter4);
                var parameter5 = new SqlParameter("@FechaHoraExpiracion", SqlDbType.DateTime) { Value = fechaHoraExpiracion };
                command.Parameters.Add(parameter5);

                conexion.Open();
                SqlDataReader SqlReader = command.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (SqlReader["Token"] != DBNull.Value)
                    {
                        token = Convert.ToString(SqlReader["Token"]);
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

            return token;
        }

    }
}