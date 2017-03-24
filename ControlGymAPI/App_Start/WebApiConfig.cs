using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

namespace ControlGymAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*Ruta para traer los programas y rutinas de un miembro*/
            config.Routes.MapHttpRoute(
                name: "MiembroPrograma",
                routeTemplate: "api/miembro/{miembroId}/programas",
                defaults: new { controller = "ProgramaEjercicio", action = "GetProgramaEjercicioByMiembro"},
                constraints: new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
            );
            config.Routes.MapHttpRoute(
                name: "ProgramaRutinas",
                routeTemplate: "api/programa/{programaId}/rutinas",
                defaults: new { controller = "Rutina", action = "GetRutinaByPrograma" },
                constraints: new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
            );

            /*Ruta para traer los horarios de una clase*/
            config.Routes.MapHttpRoute(
                name: "ClaseHorarios",
                routeTemplate: "api/clase/{claseId}/horarios",
                defaults: new { controller = "HorarioClase", action = "GetHorarioByClase" },
                // Importantisimo para que el ACTION sea registrado como un metodo GET, ante el llamado OPTIONS
                constraints: new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
            );

            /*Ruta para traer el plan nutricional de un miembro*/
            config.Routes.MapHttpRoute(
                name: "PlanNutrional",
                routeTemplate: "api/miembro/{miembroId}/PlanNutricional",
                defaults: new { controller = "PlanNutricional", action = "GetPlanNutrionalByMiembro" },
                constraints: new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
            );
            /*Ruta para traer el detalle de un plan nutricional*/
            config.Routes.MapHttpRoute(
              name: "PlanNutricionalDetalle",
              routeTemplate: "api/PlanNutricional/{plannutrionalId}/PlanNutricionalDetalle",
              defaults: new { controller = "PlanNutricionalDetalle", action = "GetPlanNutrionalDetalleByPlanNutrional" },
              constraints: new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
          );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
            
            /******************************************* CONTROL GYM API ***************************************************/
            // http://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            // Con esto nos aseguramos que la respuesta sea siempre en formato JSON
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
            //                  "text/html",
            //                  StringComparison.InvariantCultureIgnoreCase,
            //                  true,
            //                  "application/json"));
        }
    }
}
