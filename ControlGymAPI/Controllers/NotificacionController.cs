//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:48:52 a.m.
//Comentario: Generacion API


using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;

namespace ControlGymAPI.Controllers
{
    public class NotificacionController : ApiController
    {
        // Atributos
        List<NotificacionModel> listaNotificacion;
        NotificacionRepository repository = new NotificacionRepository();
        
        /**
         * GET: api/Notificacion/
        **/
        public List<NotificacionModel> GetNotificacion()
        {
            listaNotificacion = repository.RetrieveNotificacion();
            return listaNotificacion;
        }
        /**
         * GET: api/Notificacion/{id}
        **/
        public NotificacionModel GetNotificacionById(int id)
        {
            listaNotificacion = repository.RetrieveNotificacion(id);
            return listaNotificacion.First();
        }

        public NotificacionModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            NotificacionModel objeto = new NotificacionModel();
			objeto.IdMiembro = json.IdMiembro;
			objeto.IdTipoNotificacion = json.IdTipoNotificacion;

            return repository.InsertNotificacion(objeto);
        }

    }
}