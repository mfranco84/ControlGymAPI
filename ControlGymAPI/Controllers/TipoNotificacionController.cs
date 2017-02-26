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
    public class TipoNotificacionController : ApiController
    {
        // Atributos
        List<TipoNotificacionModel> listaTipoNotificacion;
        TipoNotificacionRepository repository = new TipoNotificacionRepository();
        
        /**
         * GET: api/TipoNotificacion/
        **/
        public List<TipoNotificacionModel> GetTipoNotificacion()
        {
            listaTipoNotificacion = repository.RetrieveTipoNotificacion();
            return listaTipoNotificacion;
        }
        /**
         * GET: api/TipoNotificacion/{id}
        **/
        public TipoNotificacionModel GetTipoNotificacionById(int id)
        {
            listaTipoNotificacion = repository.RetrieveTipoNotificacion(id);
            return listaTipoNotificacion.First();
        }

        public TipoNotificacionModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            TipoNotificacionModel objeto = new TipoNotificacionModel();
			objeto.Intervalo = json.Intervalo;
			objeto.Mensaje = json.Mensaje;
			objeto.Nombre = json.Nombre;

            return repository.InsertTipoNotificacion(objeto);
        }

    }
}