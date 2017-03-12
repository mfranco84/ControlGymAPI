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
    public class ExcepcionController : ApiDefaultController
    {
        // Atributos
        List<ExcepcionModel> listaExcepcion;
        ExcepcionRepository repository = new ExcepcionRepository();
        AuthRepository auth = new AuthRepository();
        
        /**
         * GET: api/Excepcion/
        **/
        public HttpResponseMessage GetExcepcion()
        {
            if (auth.ValidateToken(Request))
            {
                listaExcepcion = repository.RetrieveExcepcion();
                return Request.CreateResponse(HttpStatusCode.OK, listaExcepcion, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Excepcion/{id}
        **/
        public HttpResponseMessage GetExcepcionById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaExcepcion = repository.RetrieveExcepcion(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaExcepcion.First(), Configuration.Formatters.JsonFormatter);                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ExcepcionModel objeto = new ExcepcionModel();
            objeto.Linea_Error = json.Linea_Error;
            objeto.Mensaje_Error = json.Mensaje_Error;
            objeto.Numero_Error = json.Numero_Error;
            objeto.Parametros_Error = json.Parametros_Error;
            objeto.Procedimiento_Error = json.Procedimiento_Error;

            objeto = repository.InsertExcepcion(objeto);
            if (objeto.IdExcepcion == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}