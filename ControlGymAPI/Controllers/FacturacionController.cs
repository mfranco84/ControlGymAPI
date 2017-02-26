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
    public class FacturacionController : ApiController
    {
        // Atributos
        List<FacturacionModel> listaFacturacion;
        FacturacionRepository repository = new FacturacionRepository();
        
        /**
         * GET: api/Facturacion/
        **/
        public List<FacturacionModel> GetFacturacion()
        {
            listaFacturacion = repository.RetrieveFacturacion();
            return listaFacturacion;
        }
        /**
         * GET: api/Facturacion/{id}
        **/
        public FacturacionModel GetFacturacionById(int id)
        {
            listaFacturacion = repository.RetrieveFacturacion(id);
            return listaFacturacion.First();
        }

        public FacturacionModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            FacturacionModel objeto = new FacturacionModel();
			objeto.FechaPago = json.FechaPago;
			objeto.IdGimnasio = json.IdGimnasio;
			objeto.Monto = json.Monto;

            return repository.InsertFacturacion(objeto);
        }

    }
}