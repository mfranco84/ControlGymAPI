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
    public class MembresiaController : ApiController
    {
        // Atributos
        List<MembresiaModel> listaMembresia;
        MembresiaRepository repository = new MembresiaRepository();
        
        /**
         * GET: api/Membresia/
        **/
        public List<MembresiaModel> GetMembresia()
        {
            listaMembresia = repository.RetrieveMembresia();
            return listaMembresia;
        }
        /**
         * GET: api/Membresia/{id}
        **/
        public MembresiaModel GetMembresiaById(int id)
        {
            listaMembresia = repository.RetrieveMembresia(id);
            return listaMembresia.First();
        }

        public MembresiaModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            MembresiaModel objeto = new MembresiaModel();
			objeto.Detalle = json.Detalle;
			objeto.Monto = json.Monto;
			objeto.Nombre = json.Nombre;

            return repository.InsertMembresia(objeto);
        }

    }
}