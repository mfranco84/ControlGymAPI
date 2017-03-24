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
    public class PlanNutricionalController : ApiDefaultController
    {
        // Atributos
        List<PlanNutricionalModel> listaPlanNutricional;
        PlanNutricionalRepository repository = new PlanNutricionalRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/PlanNutricional/
        **/
        public HttpResponseMessage GetPlanNutricional()
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricional = repository.RetrievePlanNutricional();                
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricional, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        /**
         * GET: api/miembro/{miembroId}/PlanNutricional
        **/
        public HttpResponseMessage GetPlanNutrionalByMiembro(int miembroId)
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricional = repository.RetrievePlanNutrionalByMiembroId(miembroId);
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricional, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/PlanNutricional/{id}
        **/
        public HttpResponseMessage GetPlanNutricionalById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricional = repository.RetrievePlanNutricional(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricional.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            PlanNutricionalModel objeto = new PlanNutricionalModel();
            objeto.FechaFin = json.FechaFin;
            objeto.FechaInicio = json.FechaInicio;
            objeto.IdMiembro = json.IdMiembro;
            objeto.Nombre = json.Nombre;

            objeto = repository.InsertPlanNutricional(objeto);
            if (objeto.IdPlanNutricional == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}