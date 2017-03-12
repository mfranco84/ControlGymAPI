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
    public class FacturacionController : ApiDefaultController
    {
        // Atributos
        List<FacturacionModel> listaFacturacion;
        FacturacionRepository repository = new FacturacionRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Facturacion/
        **/
        public HttpResponseMessage GetFacturacion()
        {
            if (auth.ValidateToken(Request))
            {
                listaFacturacion = repository.RetrieveFacturacion();
                return Request.CreateResponse(HttpStatusCode.OK, listaFacturacion, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Facturacion/{id}
        **/
        public HttpResponseMessage GetFacturacionById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaFacturacion = repository.RetrieveFacturacion(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaFacturacion.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            FacturacionModel objeto = new FacturacionModel();
            objeto.FechaPago = json.FechaPago;
            objeto.IdGimnasio = json.IdGimnasio;
            objeto.Monto = json.Monto;

            objeto = repository.InsertFacturacion(objeto);
            if (objeto.IdFacturacion == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}