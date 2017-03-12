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
    public class AdministradorPermisoController : ApiDefaultController
    {
        // Atributos
        List<AdministradorPermisoModel> listaAdministradorPermiso;
        AdministradorPermisoRepository repository = new AdministradorPermisoRepository();
        AuthRepository auth = new AuthRepository();        

        /**
         * GET: api/AdministradorPermiso/
        **/
        public List<AdministradorPermisoModel> GetAdministradorPermiso()
        {
            listaAdministradorPermiso = repository.RetrieveAdministradorPermiso();
            return listaAdministradorPermiso;
        }
        /**
         * GET: api/AdministradorPermiso/{id}
        **/
        public AdministradorPermisoModel GetAdministradorPermisoById(int id)
        {
            listaAdministradorPermiso = repository.RetrieveAdministradorPermiso(id);
            return listaAdministradorPermiso.First();
        }

        public AdministradorPermisoModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            AdministradorPermisoModel objeto = new AdministradorPermisoModel();
			objeto.IdAdministrador = json.IdAdministrador;
			objeto.IdPermiso = json.IdPermiso;

            return repository.InsertAdministradorPermiso(objeto);
        }

    }
}