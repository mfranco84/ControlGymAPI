using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ControlGymAPI.Models;
using System.Collections.Generic;
using System.Net.Http;

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
                auth.Token = "123four";
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

                        // Alojar datos de usuario autorizado (miembro/administrador) en una variable global
                        // para su posterior uso en los diferentes stored procedures
                        GlobalAuth.IdOrganizacion = auth.IdOrganizacion;
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


        public string RegistrarToken(int usuarioId, string tipoUsuario)
        {
            string token = "123four";
            // TODO: Implementar logica para crear un registro para cada login.
            // 2- El valor de la columna fecha_hora_expiracion es:
            //        - para administrador: fecha_hora_login + 60 minutos
            //        - para miembro: fecha_hora_login + 1 mes.
            // 3- El valor del token, ejemplo: http://stackoverflow.com/questions/14643735/how-to-generate-a-unique-token-which-expires-after-24-hours
            // 4- Este metodo debe devolver el token, el cual será agregado al objeto
            //    miembro o administrador que retornan las respectivas funciones de login. 

            return token;
        }
        
    }
}