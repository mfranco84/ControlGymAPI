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
    public class LoginAdministradorController : ApiController
    {
        LoginAdministradorRepository loginAdministradorRespuesta = new LoginAdministradorRepository();

        // POST api/loginAdministrador
        public AdministradorModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            AdministradorModel administrador = new AdministradorModel();
            administrador.Correo = json.Correo;
            administrador.Clave = json.Clave;
            return loginAdministradorRespuesta.LoginAdministrador(administrador);
        }
    }
}
