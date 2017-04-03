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
using System;

namespace ControlGymAPI.Controllers
{
    public class AdministradorController : ApiDefaultController
    {
        // Atributos
        List<AdministradorModel> listaAdministrador;
        AdministradorRepository repository = new AdministradorRepository();
        AuthRepository auth = new AuthRepository();
        
        /**
         * GET: api/Administrador/
        **/
        public HttpResponseMessage GetAdministrador()
        {
            if (auth.ValidateToken(Request))
            {
                listaAdministrador = repository.RetrieveAdministrador();
                return Request.CreateResponse(HttpStatusCode.OK, listaAdministrador, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Administrador/{id}
        **/
        public HttpResponseMessage GetAdministradorById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaAdministrador = repository.RetrieveAdministrador(id);                
                return Request.CreateResponse(HttpStatusCode.OK, listaAdministrador.First(), Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
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
            //Enviar  correo de la cuenta creada
            try
            {
                if (administrador.IdAdministrador> 0)
                {
                    List<Models.GimnasioModel> Gimnasio = new List<GimnasioModel>();
                    Repositories.GimnasioRepository GimnasioRepository = new GimnasioRepository();
                    Gimnasio = GimnasioRepository.RetrieveGimnasio(administrador.IdGimnasio);
                    Notification.SendMail.SendNotificationByRegisterAdmin(administrador.Nombre, administrador.Correo, administrador.Clave, Gimnasio.FirstOrDefault().Nombre);
                }
            }
            catch (Exception ex) { }
            administrador.Clave = null;
            if (administrador.IdAdministrador > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, administrador, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            if (administrador.IdAdministrador == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.Created, administrador, Configuration.Formatters.JsonFormatter);
        }

    }
}