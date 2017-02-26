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
    public class ProgramaEjercicioController : ApiController
    {
        // Atributos
        List<ProgramaEjercicioModel> listaProgramaEjercicio;
        ProgramaEjercicioRepository repository = new ProgramaEjercicioRepository();
        
        /**
         * GET: api/ProgramaEjercicio/
        **/
        public List<ProgramaEjercicioModel> GetProgramaEjercicio()
        {
            listaProgramaEjercicio = repository.RetrieveProgramaEjercicio();
            return listaProgramaEjercicio;
        }
        /**
         * GET: api/ProgramaEjercicio/{id}
        **/
        public ProgramaEjercicioModel GetProgramaEjercicioById(int id)
        {
            listaProgramaEjercicio = repository.RetrieveProgramaEjercicio(id);
            return listaProgramaEjercicio.First();
        }

        public ProgramaEjercicioModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ProgramaEjercicioModel objeto = new ProgramaEjercicioModel();
			objeto.FechaFin = json.FechaFin;
			objeto.FechaInicio = json.FechaInicio;
			objeto.IdMiembro = json.IdMiembro;
			objeto.NombrePrograma = json.NombrePrograma;

            return repository.InsertProgramaEjercicio(objeto);
        }

    }
}