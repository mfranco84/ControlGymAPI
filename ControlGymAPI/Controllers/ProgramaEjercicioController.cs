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
    public class ProgramaEjercicioController : ApiDefaultController
    {
        // Atributos
        List<ProgramaEjercicioModel> listaProgramaEjercicio;
        ProgramaEjercicioRepository repository = new ProgramaEjercicioRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/ProgramaEjercicio/
        **/
        public HttpResponseMessage GetProgramaEjercicio()
        {
            if (auth.ValidateToken(Request))
            {
                listaProgramaEjercicio = repository.RetrieveProgramaEjercicio();
                return Request.CreateResponse(HttpStatusCode.OK, listaProgramaEjercicio, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/miembro/{miembroId}/programas
        **/
        public HttpResponseMessage GetProgramaEjercicioByMiembro(int miembroId)
        {
            if (auth.ValidateToken(Request))
            {
                listaProgramaEjercicio = repository.RetrieveProgramaEjercicioByMiembroId(miembroId);
                return Request.CreateResponse(HttpStatusCode.OK, listaProgramaEjercicio, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ProgramaEjercicioModel objeto = new ProgramaEjercicioModel();
            objeto.FechaFin = json.FechaFin;
            objeto.FechaInicio = json.FechaInicio;
            objeto.IdMiembro = json.IdMiembro;
            objeto.NombrePrograma = json.NombrePrograma;
            objeto = repository.InsertProgramaEjercicio(objeto);
            if (objeto.IdProgramaEjercicio == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage Put(JObject jsonData)
        {
            dynamic json = jsonData;
            ProgramaEjercicioModel objeto = new ProgramaEjercicioModel();
            objeto.FechaFin = json.FechaFin;
            objeto.FechaInicio = json.FechaInicio;
            objeto.IdMiembro = json.IdMiembro;
            objeto.IdProgramaEjercicio = json.IdProgramaEjercicio;
            objeto.NombrePrograma = json.NombrePrograma;
            objeto = repository.UpdateProgramaEjercicio(objeto);
            if (objeto.IdProgramaEjercicio == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
        }

    }
}