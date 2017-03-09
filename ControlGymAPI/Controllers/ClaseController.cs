//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:48:52 a.m.
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
    public class ClaseController : ApiController
    {
        // Atributos
        List<ClaseModel> listaClase;
        ClaseRepository repository = new ClaseRepository();

        public HttpResponseMessage Options()
        {
            // return null; // HTTP 200 response with empty body
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /**
         * GET: api/Clase/
        **/
        public List<ClaseModel> GetClase()
        {
            listaClase = repository.RetrieveClase();
            return listaClase;
        }
        /**
         * GET: api/Clase/{id}
        **/
        public ClaseModel GetClaseById(int id)
        {
            listaClase = repository.RetrieveClase(id);
            return listaClase.First();
        }

        public ClaseModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ClaseModel objeto = new ClaseModel();
			objeto.Nombre = json.Nombre;

            return repository.InsertClase(objeto);
        }

    }
}