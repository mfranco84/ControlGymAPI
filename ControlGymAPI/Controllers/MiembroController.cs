using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace ControlGymAPI.Controllers
{
    public class MiembroController : ApiController
    {
        // Atributos
        List<MiembroModel> listaMiembros;
        MiembroRepository miembroRep = new MiembroRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Miembro/
        **/
        public HttpResponseMessage GetMiembros()
        {
            if (auth.ValidateToken(Request))
            {
                listaMiembros = miembroRep.RetrieveMiembros();
                return Request.CreateResponse(HttpStatusCode.OK, listaMiembros, Configuration.Formatters.JsonFormatter);
                // return listaMiembros;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Miembro/{id}
        **/
        public MiembroModel GetMiembroById(int id)
        {
            listaMiembros = miembroRep.RetrieveMiembro(id);
            return listaMiembros.First();
        }

        public MiembroModel Post(JObject jsonData)
        {
            // una variable de tipo dynamic nos permite acceder 
            // las propiedades de la variable como si fuese un Objeto
            dynamic json = jsonData;
            MiembroModel miembro = new MiembroModel();
            miembro.IdGimnasio = json.IdGimnasio;
            miembro.Correo = json.Correo;
            miembro.Nombre = json.Nombre;
            miembro.Telefono = json.Telefono;
            miembro.CedulaIdentidad = json.CedulaIdentidad;
            miembro.Direccion = json.Direccion;

            return miembroRep.InsertMiembro(miembro);
        }

    }
}
