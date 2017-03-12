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
    public class PermisoController : ApiDefaultController
    {
        // Atributos
        List<PermisoModel> listaPermiso;
        PermisoRepository repository = new PermisoRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Permiso/
        **/
        public HttpResponseMessage GetPermiso()
        {
            if (auth.ValidateToken(Request))
            {
                listaPermiso = repository.RetrievePermiso();
                return Request.CreateResponse(HttpStatusCode.OK, listaPermiso, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Permiso/{id}
        **/
        public HttpResponseMessage GetPermisoById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaPermiso = repository.RetrievePermiso(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaPermiso.First(), Configuration.Formatters.JsonFormatter);                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            PermisoModel objeto = new PermisoModel();
            objeto.Detalle = json.Detalle;
            objeto.Nombre = json.Nombre;

            objeto = repository.InsertPermiso(objeto);
            if (objeto.IdPermiso == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}