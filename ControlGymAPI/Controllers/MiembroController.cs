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
    public class MiembroController : ApiDefaultController
    {
        // Atributos
        List<MiembroModel> listaMiembros;
        MiembroRepository miembroRep = new MiembroRepository();
        AuthRepository auth = new AuthRepository();

        /**
         * GET: api/Miembro/
        **/
        public HttpResponseMessage GetMiembros()
        {
            if (auth.ValidateToken(Request))
            {
                listaMiembros = miembroRep.RetrieveMiembros();
                return Request.CreateResponse(HttpStatusCode.OK, listaMiembros, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
        /**
         * GET: api/Miembro/{id}
        **/
        public HttpResponseMessage GetMiembroById(int id)
        {
            if (auth.ValidateToken(Request))
            {
                listaMiembros = miembroRep.RetrieveMiembro(id);
                return Request.CreateResponse(HttpStatusCode.OK, listaMiembros.First(), Configuration.Formatters.JsonFormatter);
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
                // una variable de tipo dynamic nos permite acceder 
                // las propiedades de la variable como si fuese un Objeto
                dynamic json = jsonData;
                MiembroModel miembro = new MiembroModel();
                miembro.IdGimnasio = json.IdGimnasio;
                miembro.Correo = json.Correo;
                miembro.Nombre = json.Nombre;
                miembro.Telefono = json.Telefono;
                miembro.CedulaIdentidad = json.CedulaIdentidad;
                miembro.Direccion = json.Direccion;
                if (miembro.IdGimnasio == 0 || String.IsNullOrEmpty(miembro.Nombre))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                miembro = miembroRep.InsertMiembro(miembro);
                //Enviar  correo de la cuenta creada
                try
                {
                    if (miembro.IdMiembro>0)
                    {
                        List<Models.GimnasioModel> Gimnasio = new List<GimnasioModel>();
                        Repositories.GimnasioRepository GimnasioRepository = new GimnasioRepository();
                        Gimnasio = GimnasioRepository.RetrieveGimnasio(miembro.IdGimnasio);
                        Notification.SendMail.SendNotificationByRegister(miembro.Nombre, miembro.Correo, miembro.Clave,Gimnasio.FirstOrDefault().Nombre);
                    }
                    
                }
                catch (Exception ex) { }
                miembro.Clave = null;
                if (miembro.IdMiembro > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, miembro, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden);
                }
                
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
                // una variable de tipo dynamic nos permite acceder 
                // las propiedades de la variable como si fuese un Objeto
                dynamic json = jsonData;
                MiembroModel miembro = new MiembroModel();
                miembro.IdMiembro = json.IdMiembro;
                miembro.IdGimnasio = json.IdGimnasio;
                miembro.Correo = json.Correo;
                miembro.Nombre = json.Nombre;
                miembro.Telefono = json.Telefono;
                miembro.CedulaIdentidad = json.CedulaIdentidad;
                miembro.Direccion = json.Direccion;
                if (miembro.IdMiembro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                miembro = miembroRep.UpdateMiembro(miembro);
                return Request.CreateResponse(HttpStatusCode.OK, miembro, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

    }
}
