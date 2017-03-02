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
            if (request.Headers.TryGetValues("cgToken", out headerValues))
            {
                tokenHeader = headerValues.FirstOrDefault();
                if (tokenHeader != "123four")
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            // TODO: Implementar logica para validar el token.
            //1- Verificar existencia del token, de no existir, retornar un false;
            //2- Verificar que la fecha y hora actual sean menores que fechaHoraExpiracion,
            //    de no ser menor, retornar false.
            //3- Sumarle a la fechaHoraExpiracion:
            //        - para administrador: + 60 minutos
            //        - para miembro: + 1 mes.
            //4- Buscar y alojar el  miembro/administrador en una variable global y retornar true
            return true;
        }


        public string RegistrarToken(int usuarioId, string tipoUsuario)
        {
            string token = "123four";
            // TODO: Implementar logica para crear un registro para cada login.
            // 1- Este metodo sera llamado desde las clases LoginAdministradorRepository y LoginMiembroRepository.
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