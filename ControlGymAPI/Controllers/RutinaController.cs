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
    public class RutinaController : ApiController
    {
        // Atributos
        List<RutinaModel> listaRutina;
        RutinaRepository repository = new RutinaRepository();
        
        /**
         * GET: api/Rutina/
        **/
        public List<RutinaModel> GetRutina()
        {
            listaRutina = repository.RetrieveRutina();
            return listaRutina;
        }
        /**
         * GET: api/Rutina/{id}
        **/
        public RutinaModel GetRutinaById(int id)
        {
            listaRutina = repository.RetrieveRutina(id);
            return listaRutina.First();
        }

        public RutinaModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            RutinaModel objeto = new RutinaModel();
			objeto.DetalleRutina = json.DetalleRutina;
			objeto.IdProgramaEjercicio = json.IdProgramaEjercicio;
			objeto.NombreRutina = json.NombreRutina;

            return repository.InsertRutina(objeto);
        }

    }
}