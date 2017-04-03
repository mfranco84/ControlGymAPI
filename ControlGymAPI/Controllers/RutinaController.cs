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
    public class RutinaController : ApiDefaultController
    {
        // Atributos
        List<RutinaModel> listaRutina;
        RutinaRepository repository = new RutinaRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Rutina/
        **/
        public HttpResponseMessage GetRutina()
        {
            if (auth.ValidateToken(Request))
            {
                listaRutina = repository.RetrieveRutina();
                return Request.CreateResponse(HttpStatusCode.OK, listaRutina, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/programa/{{programaId}}/rutinas
        **/
        public HttpResponseMessage GetRutinaByPrograma(int programaId)
        {
            if (auth.ValidateToken(Request))
            {
                listaRutina = repository.RetrieveRutinaByProgramaId(programaId);
                return Request.CreateResponse(HttpStatusCode.OK, listaRutina, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        /**
         * GET: api/Rutina/{id}
        **/
        public HttpResponseMessage GetRutinaById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaRutina = repository.RetrieveRutina(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaRutina.First(), Configuration.Formatters.JsonFormatter);
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
                RutinaModel objeto = new RutinaModel();
                objeto.DetalleRutina = json.DetalleRutina;
                objeto.IdProgramaEjercicio = json.IdProgramaEjercicio;
                objeto.NombreRutina = json.NombreRutina;

                objeto = repository.InsertRutina(objeto);
                if (objeto.IdRutina == 0)
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
                RutinaModel objeto = new RutinaModel();
                objeto.DetalleRutina = json.DetalleRutina;
                objeto.IdProgramaEjercicio = json.IdProgramaEjercicio;
                objeto.IdRutina = json.IdRutina;
                objeto.NombreRutina = json.NombreRutina;

                objeto = repository.UpdateRutina(objeto);
                if (objeto.IdRutina == 0)
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