using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System;

namespace ControlGymAPI.Controllers
{
    public class DeviceTokenController : ApiDefaultController
    {
        // Atributos
        List<MiembroModel> listaMiembros;
        MiembroRepository miembroRep = new MiembroRepository();
        AuthRepository auth = new AuthRepository();


        /**
         * POST: api/deviceToken
        **/
        public HttpResponseMessage Post(JObject jsonData)
        {
            if (auth.ValidateToken(Request))
            {
                // una variable de tipo dynamic nos permite acceder 
                // las propiedades de la variable como si fuese un Objeto
                dynamic json = jsonData;
                MiembroModel miembro = new MiembroModel();
                miembro.IdMiembro = json.IdMiembro;
                listaMiembros = miembroRep.RetrieveMiembro(miembro.IdMiembro);
                miembro = listaMiembros.First();
                miembro.DeviceToken = json.DeviceToken;
                if (json.IdMiembro == 0 || String.IsNullOrEmpty(miembro.DeviceToken))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                miembro = miembroRep.UpdateMiembroDeviceToken(miembro);
                return Request.CreateResponse(HttpStatusCode.Created, miembro, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

    }
}
