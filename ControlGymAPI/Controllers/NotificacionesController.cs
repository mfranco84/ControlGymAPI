using ControlGymAPI.Notification;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGymAPI.Controllers
{
    public class NotificacionesController : ApiDefaultController
    {
        AuthRepository auth = new AuthRepository();

        // POST api/notificaciones
        public HttpResponseMessage Post(JObject jsonData)
        {
            if (auth.ValidateToken(Request))
            {
                dynamic json = jsonData;
                var Nombre = Convert.ToString(json.Nombre);
                var Correo = Convert.ToString(json.Correo);
                bool respuesta = SendMail.SendNotificationByRegister(Nombre, Correo, "","GymControl");
                return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
    }
}
