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
using ControlGymAPI.Services;
using System;

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
            if (auth.ValidateToken(Request))
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
                MiembroRepository miembroRep = new MiembroRepository();
                MiembroModel miembro = miembroRep.RetrieveMiembrosById((int)objeto.IdMiembro).First();
                FirebaseNotification fbn = new FirebaseNotification();
                if (!string.IsNullOrEmpty(miembro.DeviceToken))
                {
                    fbn.post(miembro.DeviceToken, "Nuevo Programa", "Tienes un nuevo programa de ejercicio " + objeto.NombrePrograma);
                }
                return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
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
                MiembroRepository miembroRep = new MiembroRepository();
                MiembroModel miembro = miembroRep.RetrieveMiembrosById((int) objeto.IdMiembro).First();
                FirebaseNotification fbn = new FirebaseNotification();
                if (!string.IsNullOrEmpty(miembro.DeviceToken))
                {
                    fbn.post(miembro.DeviceToken, "Programa actualizado", "Se ha actualizado tu programa de ejercicio " + objeto.NombrePrograma);
                }
                return Request.CreateResponse(HttpStatusCode.Created, objeto, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

    }
}