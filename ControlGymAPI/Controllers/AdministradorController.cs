//Creado por: Generado Automaticamente
//Fecha de Creacion: 26/02/2017 09:31:40 a.m.
//Comentario: Generacion API


using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ControlGymAPI.Models;
using ControlGymAPI.Repositories;
using Newtonsoft.Json.Linq;

namespace ControlGymAPI.Controllers
{
    public class AdministradorController : ApiController
    {
        // Atributos
        List<AdministradorModel> listaAdministrador;
        AdministradorRepository repository = new AdministradorRepository();

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

        public AdministradorModel Post(JObject jsonData)
        {
            dynamic json = jsonData;
            AdministradorModel objeto = new AdministradorModel();
            objeto.IdAdministrador = json.IdAdministrador;
            objeto.UsuInclusion = json.UsuInclusion;
            objeto.FechaInclusion = json.FechaInclusion;
            objeto.UsuModificacion = json.UsuModificacion;
            objeto.FechaModificacion = json.FechaModificacion;
            objeto.Estado = json.Estado;
            objeto.IdGimnasio = json.IdGimnasio;
            objeto.Correo = json.Correo;
            objeto.Clave = json.Clave;
            objeto.Nombre = json.Nombre;
            objeto.Telefono = json.Telefono;
            objeto.CedulaJuridica = json.CedulaJuridica;
            objeto.Direccion = json.Direccion;

            return repository.InsertAdministrador(objeto);
        }

    }
}