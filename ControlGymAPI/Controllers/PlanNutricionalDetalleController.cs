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
    public class PlanNutricionalDetalleController : ApiDefaultController
    {
        // Atributos
        List<PlanNutricionalDetalleModel> listaPlanNutricionalDetalle;
        PlanNutricionalDetalleRepository repository = new PlanNutricionalDetalleRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/PlanNutricionalDetalle/
        **/
        public HttpResponseMessage GetPlanNutricionalDetalle()
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricionalDetalle = repository.RetrievePlanNutricionalDetalle();
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricionalDetalle, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
     * GET: api/PlanNutricional/{{plannutrionalId}}/PlanNutricionalDetalle
    **/
        public HttpResponseMessage GetPlanNutrionalDetalleByPlanNutrional(int plannutrionalId)
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricionalDetalle = repository.RetrievePlanNutrionalByPlanId(plannutrionalId);
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricionalDetalle, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        /**
         * GET: api/PlanNutricionalDetalle/{id}
        **/
        public HttpResponseMessage GetPlanNutricionalDetalleById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaPlanNutricionalDetalle = repository.RetrievePlanNutricionalDetalle(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaPlanNutricionalDetalle.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            if (auth.ValidateToken(Request))
            {
                dynamic json = jsonData;
                PlanNutricionalDetalleModel objeto = new PlanNutricionalDetalleModel();
                objeto.Detalle = json.Detalle;
                objeto.IdPlanNutricional = json.IdPlanNutricional;
                objeto = repository.InsertPlanNutricionalDetalle(objeto);
                if (objeto.IdPlanNutricionalDetalle == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            
        }

        public HttpResponseMessage Put(JObject jsonData)
        {
            if (auth.ValidateToken(Request))
            {
                dynamic json = jsonData;
                PlanNutricionalDetalleModel objeto = new PlanNutricionalDetalleModel();
                objeto.Detalle = json.Detalle;
                objeto.IdPlanNutricional = json.IdPlanNutricional;
                objeto.IdPlanNutricionalDetalle = json.IdPlanNutricionalDetalle;
                objeto = repository.UpdatePlanNutricionalDetalle(objeto);
                if (objeto.IdPlanNutricionalDetalle == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

        }

    }
}