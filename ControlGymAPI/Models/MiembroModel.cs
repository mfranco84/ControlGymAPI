using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlGymAPI.Models
{
    public class MiembroModel
    {
        public Int32 IdMiembro;
        public string UsuInclusion;
        public DateTime FechaInclusion;
        public string UsuModificacion;
        public DateTime FechaModificacion;
        public Int32 Estado;
        public Int32 IdGimnasio;
        public string Correo;
        public string Clave;
        public string Nombre;
        public string Telefono;
        public string CedulaIdentidad;
        public string Direccion;
        // Atributo usado unicamente cuando se hace el login
        public string Token;
    }
}