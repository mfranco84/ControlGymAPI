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
    public class MembresiaController : ApiDefaultController
    {
        // Atributos
        List<MembresiaModel> listaMembresia;
        MembresiaRepository repository = new MembresiaRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Membresia/
        **/
        public HttpResponseMessage GetMembresia()
        {
            if (auth.ValidateToken(Request))
            {
                listaMembresia = repository.RetrieveMembresia();
                return Request.CreateResponse(HttpStatusCode.OK, listaMembresia, Configuration.Formatters.JsonFormatter);                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Membresia/{id}
        **/
        public HttpResponseMessage GetMembresiaById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaMembresia = repository.RetrieveMembresia(id);            
                return Request.CreateResponse(HttpStatusCode.OK, listaMembresia.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            MembresiaModel objeto = new MembresiaModel();
			objeto.Detalle = json.Detalle;
			objeto.Monto = json.Monto;
			objeto.Nombre = json.Nombre;

            objeto = repository.InsertMembresia(objeto);
            if (objeto.IdMembresia == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}