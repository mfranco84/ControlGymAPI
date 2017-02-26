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
    public class ExcepcionController : ApiController
    {
        // Atributos
        List<ExcepcionModel> listaExcepcion;
        ExcepcionRepository repository = new ExcepcionRepository();
        
        /**
         * GET: api/Excepcion/
        **/
        public List<ExcepcionModel> GetExcepcion()
        {
            listaExcepcion = repository.RetrieveExcepcion();
            return listaExcepcion;
        }
        /**
         * GET: api/Excepcion/{id}
        **/
        public ExcepcionModel GetExcepcionById(int id)
        {
            listaExcepcion = repository.RetrieveExcepcion(id);
            return listaExcepcion.First();
        }

        public ExcepcionModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            ExcepcionModel objeto = new ExcepcionModel();
			objeto.Linea_Error = json.Linea_Error;
			objeto.Mensaje_Error = json.Mensaje_Error;
			objeto.Numero_Error = json.Numero_Error;
			objeto.Parametros_Error = json.Parametros_Error;
			objeto.Procedimiento_Error = json.Procedimiento_Error;

            return repository.InsertExcepcion(objeto);
        }

    }
}