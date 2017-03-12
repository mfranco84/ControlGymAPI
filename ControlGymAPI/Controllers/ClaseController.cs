//Creado por: Generado Automaticamente
//Fecha de Creacion: 09/03/2017 04:23:08 p.m.
//Comentario: Generacion API


using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace ControlGymAPI.Controllers
{
    public class ClaseController : ApiDefaultController
    {
        // Atributos
        List<ClaseModel> listaClase;
        ClaseRepository repository = new ClaseRepository();
        AuthRepository auth = new AuthRepository();        

        /**
         * GET: api/Clase/
        **/
        public HttpResponseMessage GetClase()
        {
            if (auth.ValidateToken(Request))
            {
                listaClase = repository.RetrieveClase();
                return Request.CreateResponse(HttpStatusCode.OK, listaClase, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Clase/{id}
        **/
        public HttpResponseMessage GetClaseById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaClase = repository.RetrieveClase(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaClase, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ClaseModel objeto = new ClaseModel();
            objeto.IdGimnasio = json.IdGimnasio;
            objeto.Nombre = json.Nombre;

            objeto = repository.InsertClase(objeto);

            if (objeto.IdClase == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}