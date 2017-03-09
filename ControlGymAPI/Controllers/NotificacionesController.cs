using ControlGymAPI.Notification;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGymAPI.Controllers
{
    public class NotificacionesController : ApiController
    {
        // POST api/notificaciones
        public bool Post(JObject jsonData)
        {
            dynamic json = jsonData;
            var Nombre = Convert.ToString(json.Nombre);
            var Correo = Convert.ToString(json.Correo);
            return SendMail.SendNotificationByRegister(Nombre,Correo, "");
        }
    }
}
