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
    public class EstadoController : ApiDefaultController
    {
        // Atributos
        List<EstadoModel> listaEstado;
        EstadoRepository repository = new EstadoRepository();
        AuthRepository auth = new AuthRepository();        

        /**
         * GET: api/Estado/
        **/
        public HttpResponseMessage GetEstado()
        {
            if (auth.ValidateToken(Request))
            {
                listaEstado = repository.RetrieveEstado();
                return Request.CreateResponse(HttpStatusCode.OK, listaEstado, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Estado/{id}
        **/
        public HttpResponseMessage GetEstadoById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaEstado = repository.RetrieveEstado(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaEstado.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            EstadoModel objeto = new EstadoModel();
            objeto.Descripcion = json.Descripcion;
            objeto.IdEstado = json.IdEstado;

            objeto = repository.InsertEstado(objeto);
            if (objeto.IdEstado == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}