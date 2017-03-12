using ControlGymAPI.Models;
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
    public class LoginMiembroController : ApiDefaultController
    {
        LoginMiembroRepository loginMiembroRespuesta = new LoginMiembroRepository();

        // POST api/loginMiembro
        public MiembroModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            MiembroModel miembro = new MiembroModel();
            miembro.Correo = json.Correo;
            miembro.Clave = json.Clave;
            return loginMiembroRespuesta.LoginMiembro(miembro);
        }
    }
}
