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
    public class PermisoController : ApiController
    {
        // Atributos
        List<PermisoModel> listaPermiso;
        PermisoRepository repository = new PermisoRepository();
        
        /**
         * GET: api/Permiso/
        **/
        public List<PermisoModel> GetPermiso()
        {
            listaPermiso = repository.RetrievePermiso();
            return listaPermiso;
        }
        /**
         * GET: api/Permiso/{id}
        **/
        public PermisoModel GetPermisoById(int id)
        {
            listaPermiso = repository.RetrievePermiso(id);
            return listaPermiso.First();
        }

        public PermisoModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            PermisoModel objeto = new PermisoModel();
			objeto.Detalle = json.Detalle;
			objeto.Nombre = json.Nombre;

            return repository.InsertPermiso(objeto);
        }

    }
}