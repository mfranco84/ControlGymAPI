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
    public class PlanNutricionalController : ApiController
    {
        // Atributos
        List<PlanNutricionalModel> listaPlanNutricional;
        PlanNutricionalRepository repository = new PlanNutricionalRepository();
        
        /**
         * GET: api/PlanNutricional/
        **/
        public List<PlanNutricionalModel> GetPlanNutricional()
        {
            listaPlanNutricional = repository.RetrievePlanNutricional();
            return listaPlanNutricional;
        }
        /**
         * GET: api/PlanNutricional/{id}
        **/
        public PlanNutricionalModel GetPlanNutricionalById(int id)
        {
            listaPlanNutricional = repository.RetrievePlanNutricional(id);
            return listaPlanNutricional.First();
        }

        public PlanNutricionalModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            PlanNutricionalModel objeto = new PlanNutricionalModel();
			objeto.FechaFin = json.FechaFin;
			objeto.FechaInicio = json.FechaInicio;
			objeto.IdMiembro = json.IdMiembro;
			objeto.Nombre = json.Nombre;

            return repository.InsertPlanNutricional(objeto);
        }

    }
}