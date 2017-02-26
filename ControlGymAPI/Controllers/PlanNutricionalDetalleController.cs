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
    public class PlanNutricionalDetalleController : ApiController
    {
        // Atributos
        List<PlanNutricionalDetalleModel> listaPlanNutricionalDetalle;
        PlanNutricionalDetalleRepository repository = new PlanNutricionalDetalleRepository();
        
        /**
         * GET: api/PlanNutricionalDetalle/
        **/
        public List<PlanNutricionalDetalleModel> GetPlanNutricionalDetalle()
        {
            listaPlanNutricionalDetalle = repository.RetrievePlanNutricionalDetalle();
            return listaPlanNutricionalDetalle;
        }
        /**
         * GET: api/PlanNutricionalDetalle/{id}
        **/
        public PlanNutricionalDetalleModel GetPlanNutricionalDetalleById(int id)
        {
            listaPlanNutricionalDetalle = repository.RetrievePlanNutricionalDetalle(id);
            return listaPlanNutricionalDetalle.First();
        }

        public PlanNutricionalDetalleModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            PlanNutricionalDetalleModel objeto = new PlanNutricionalDetalleModel();
			objeto.Detalle = json.Detalle;
			objeto.IdPlanNutricional = json.IdPlanNutricional;

            return repository.InsertPlanNutricionalDetalle(objeto);
        }

    }
}