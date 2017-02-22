using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGymAPI.Models
{
    public class GimnasioModel
    {
        public Int32 IdGimnasio;
        public string UsuInclusion;
        public DateTime FechaInclusion;
        public string UsuModificacion;
        public DateTime FechaModificacion;
        public Int32 Estado;
        public Int32 IdMembresia;
        public string Nombre;
    }
}