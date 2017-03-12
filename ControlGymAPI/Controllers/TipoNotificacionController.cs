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
    public class TipoNotificacionController : ApiDefaultController
    {
        // Atributos
        List<TipoNotificacionModel> listaTipoNotificacion;
        TipoNotificacionRepository repository = new TipoNotificacionRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/TipoNotificacion/
        **/
        public HttpResponseMessage GetTipoNotificacion()
        {
            if (auth.ValidateToken(Request))
            {
                listaTipoNotificacion = repository.RetrieveTipoNotificacion();                
                return Request.CreateResponse(HttpStatusCode.OK, listaTipoNotificacion, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/TipoNotificacion/{id}
        **/
        public HttpResponseMessage GetTipoNotificacionById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaTipoNotificacion = repository.RetrieveTipoNotificacion(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaTipoNotificacion.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            TipoNotificacionModel objeto = new TipoNotificacionModel();
            objeto.Intervalo = json.Intervalo;
            objeto.Mensaje = json.Mensaje;
            objeto.Nombre = json.Nombre;

            objeto = repository.InsertTipoNotificacion(objeto);
            if (objeto.IdTipoNotificacion == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}