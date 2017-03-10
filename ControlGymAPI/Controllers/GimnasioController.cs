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
    public class GimnasioController : ApiController
    {
        // Atributos
        List<GimnasioModel> listaGimnasios;
        GimnasioRepository GimnasioRep = new GimnasioRepository();

        public HttpResponseMessage Options()
        {
            // return null; // HTTP 200 response with empty body
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET api/gimnasio
        public List<GimnasioModel> GetGimmasios()
        {
            return GimnasioRep.RetrieveGimnasios();
        }

        // GET api/gimnasio/5
        public GimnasioModel GetGimnasioById(int id)
        {
            listaGimnasios = GimnasioRep.RetrieveGimnasio(id);
            return listaGimnasios.First();
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
