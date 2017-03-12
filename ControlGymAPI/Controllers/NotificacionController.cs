//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:48:52 a.m.
//Comentario: Generacion API


using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace ControlGymAPI.Controllers
{
    public class NotificacionController : ApiDefaultController
    {
        // Atributos
        List<NotificacionModel> listaNotificacion;
        NotificacionRepository repository = new NotificacionRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Notificacion/
        **/
        public HttpResponseMessage GetNotificacion()
        {
            if (auth.ValidateToken(Request))
            {
                listaNotificacion = repository.RetrieveNotificacion();
                return Request.CreateResponse(HttpStatusCode.OK, listaNotificacion, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        /**
         * GET: api/Notificacion/{id}
        **/
        public HttpResponseMessage GetNotificacionById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaNotificacion = repository.RetrieveNotificacion();
                return Request.CreateResponse(HttpStatusCode.OK, listaNotificacion.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            NotificacionModel objeto = new NotificacionModel();
            objeto.IdMiembro = json.IdMiembro;
            objeto.IdTipoNotificacion = json.IdTipoNotificacion;

            objeto = repository.InsertNotificacion(objeto);
            if (objeto.IdMiembro == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}