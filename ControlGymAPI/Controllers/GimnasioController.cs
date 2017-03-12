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
    public class GimnasioController : ApiDefaultController
    {
        // Atributos
        List<GimnasioModel> listaGimnasios;
        GimnasioRepository GimnasioRep = new GimnasioRepository();
        AuthRepository auth = new AuthRepository();        

        // GET api/gimnasio
        public HttpResponseMessage GetGimmasios()
        {
            if (auth.ValidateToken(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, GimnasioRep.RetrieveGimnasios(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        // GET api/gimnasio/5
        public HttpResponseMessage GetGimnasioById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaGimnasios = GimnasioRep.RetrieveGimnasio(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaGimnasios.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        // POST api/gimnasio
        public HttpResponseMessage Post(JObject jsonData)
        {
            // una variable de tipo dynamic nos permite acceder 
            // las propiedades de la variable como si fuese un Objeto
            dynamic json = jsonData;
            GimnasioModel gimnasio = new GimnasioModel();
            gimnasio.IdMembresia = json.IdMembresia;
            gimnasio.Nombre = json.Nombre;

            gimnasio = GimnasioRep.InsertGimnasio(gimnasio);
            if (gimnasio.IdGimnasio == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, gimnasio, Configuration.Formatters.JsonFormatter);
        }

        // PUT api/gimnasio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/gimnasio/5
        public void Delete(int id)
        {
        }
    }
}
