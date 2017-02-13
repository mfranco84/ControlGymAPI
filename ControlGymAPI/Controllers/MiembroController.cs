using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;

namespace ControlGymAPI.Controllers
{
    public class MiembroController : ApiController
    {
        /**
         * GET: api/Miembro/
        **/
        public List<MiembroModel> Get()
        {
            List<MiembroModel> listaMiembros; 
            var miembroRep = new MiembroRepository();
            listaMiembros = miembroRep.RetrieveMiembros();
            return listaMiembros;
        }

        public MiembroModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            return new MiembroModel
            {
                IdMiembro = 3000,
                Correo = json.Correo,
                Nombre = json.Nombre
            };
        }

    }
}
