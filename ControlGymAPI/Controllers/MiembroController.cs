using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ControlGymAPI.Models;

namespace ControlGymAPI.Controllers
{
    public class MiembroController : ApiController
    {
        //
        // GET: /Miembro/

        /*public ActionResult Index()
        {
            return View();
        }*/

        public Miembro[] Get()
        {
            return new Miembro[]
            {
                new Miembro
                {
                    Id = 1,
                    Name = "Glenn Block"
                },
                new Miembro
                {
                    Id = 2,
                    Name = "Dan Roth"
                }
            };
        }


    }
}
