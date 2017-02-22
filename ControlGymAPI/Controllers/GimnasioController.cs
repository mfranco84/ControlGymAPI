using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGymAPI.Controllers
{
    public class GimnasioController : ApiController
    {
        // Atributos
        List<GimnasioModel> listaGimnasios;
        GimnasioRepository GimnasioRep = new GimnasioRepository();

        // GET api/gimnasio

        public List<GimnasioModel> GetGimmasios()
        {
            return GimnasioRep.RetrieveGimnasios();
        }

        // GET api/gimnasio/5
        public GimnasioModel GetGimnasioById(int id)
        {
            listaGimnasios = GimnasioRep.RetrieveGimnasio(id);
            return listaGimnasios.First();
        }

        // POST api/gimnasio
        public GimnasioModel Post(JObject jsonData)
        {
            // una variable de tipo dynamic nos permite acceder 
            // las propiedades de la variable como si fuese un Objeto
            dynamic json = jsonData;
            GimnasioModel miembro = new GimnasioModel();
            miembro.IdMembresia = json.IdMembresia;
            miembro.Nombre = json.Nombre;

            return GimnasioRep.InsertGimnasio(miembro);
        }

        // PUT api/gimnasio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/gimnasio/5
        public void Delete(int id)
        {
        }
    }
}
