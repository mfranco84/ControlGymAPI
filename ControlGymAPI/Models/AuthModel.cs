using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGymAPI.Models
{
    public class AuthModel
    {
        public Int32 IdUsuario;
        public Int32 IdGimnasio;
        public string TipoUsuario;
        public DateTime FechaHoraLogin;
        public DateTime FechaHoraExpiracion;
        public string Token;
    }
}