using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGymAPI
{
    public static class GlobalAuth
    {
        public static Int32 IdUsuario { get; set; }
        public static Int32 IdOrganizacion { get; set; }
        public static string TipoUsuario { get; set; }
    }
}