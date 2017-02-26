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
    public class EstadoController : ApiController
    {
        // Atributos
        List<EstadoModel> listaEstado;
        EstadoRepository repository = new EstadoRepository();
        
        /**
         * GET: api/Estado/
        **/
        public List<EstadoModel> GetEstado()
        {
            listaEstado = repository.RetrieveEstado();
            return listaEstado;
        }
        /**
         * GET: api/Estado/{id}
        **/
        public EstadoModel GetEstadoById(int id)
        {
            listaEstado = repository.RetrieveEstado(id);
            return listaEstado.First();
        }

        public EstadoModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            EstadoModel objeto = new EstadoModel();
			objeto.Descripcion = json.Descripcion;
			objeto.IdEstado = json.IdEstado;

            return repository.InsertEstado(objeto);
        }

    }
}