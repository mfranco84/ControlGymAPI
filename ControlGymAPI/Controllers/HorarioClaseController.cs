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
    public class HorarioClaseController : ApiDefaultController
    {
        // Atributos
        List<HorarioClaseModel> listaHorarioClase;
        HorarioClaseRepository repository = new HorarioClaseRepository();
        AuthRepository auth = new AuthRepository();


        /**
         * GET: api/HorarioClase/
        **/
        public List<HorarioClaseModel> GetHorarioClase()
        {
            listaHorarioClase = repository.RetrieveHorarioClase();
            return listaHorarioClase;
        }
        /**
         * GET: api/HorarioClase/{id}
        **/
        public HorarioClaseModel GetHorarioClaseById(int id)
        {
            listaHorarioClase = repository.RetrieveHorarioClase(id);
            return listaHorarioClase.First();
        }

        /**
         * GET: api/miembro/{miembroId}/programas
        **/
        //[HttpGet]
        //[ActionName("GetHorarioByClase")]
        // [AcceptVerbs("GET", "OPTIONS")]
        public HttpResponseMessage GetHorarioByClase(int claseId)
        {
            if (auth.ValidateToken(Request))
            {
                listaHorarioClase = repository.RetrieveHorarioByClaseId(claseId);
                return Request.CreateResponse(HttpStatusCode.OK, listaHorarioClase, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        public HorarioClaseModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            HorarioClaseModel objeto = new HorarioClaseModel();
			objeto.Dia = json.Dia;
			objeto.HoraFin = json.HoraFin;
			objeto.HoraInicio = json.HoraInicio;
			objeto.IdClase = json.IdClase;

            return repository.InsertHorarioClase(objeto);
        }

    }
}