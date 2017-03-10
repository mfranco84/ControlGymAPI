//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:31:40 a.m.
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
    public class AdministradorController : ApiController
    {
        // Atributos
        List<AdministradorModel> listaAdministrador;
        AdministradorRepository repository = new AdministradorRepository();

        public HttpResponseMessage Options()
        {
            // return null; // HTTP 200 response with empty body
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /**
         * GET: api/Administrador/
        **/
        public List<AdministradorModel> GetAdministrador()
        {
            listaAdministrador = repository.RetrieveAdministrador();
            return listaAdministrador;
        }
        /**
         * GET: api/Administrador/{id}
        **/
        public AdministradorModel GetAdministradorById(int id)
        {
            listaAdministrador = repository.RetrieveAdministrador(id);
            return listaAdministrador.First();
        }

        public HttpResponseMessage Post(JObject jsonData)
        {
            dynamic json = jsonData;
            AdministradorModel administrador = new AdministradorModel();
            administrador.IdGimnasio = json.IdGimnasio;
            administrador.Correo = json.Correo;
            administrador.Clave = json.Clave;
            administrador.Nombre = json.Nombre;
            administrador.Telefono = json.Telefono;
            administrador.CedulaJuridica = json.CedulaJuridica;
            administrador.Direccion = json.Direccion;

            administrador = repository.InsertAdministrador(administrador);
            if (administrador.IdAdministrador == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, administrador, Configuration.Formatters.JsonFormatter);
        }

    }
}